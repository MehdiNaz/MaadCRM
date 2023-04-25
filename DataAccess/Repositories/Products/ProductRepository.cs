namespace DataAccess.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly MaadContext _context;

    public ProductRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ProductCategoryResponse>> GetAllProductsAsync(Ulid businessId)
    {

        var result = await _context.Products.Where(x => x.StatusProduct == Status.Show)
            .Include(c => c.ProductCategoryIdNavigation)
            .Where(x => x.ProductCategoryIdNavigation.BusinessId == businessId)
            .Select(x => new ProductCategoryResponse
            {
                ProductId = x.Id,
                Title = x.Title,
                CategoryName = x.ProductCategoryIdNavigation.ProductCategoryName,
                Discount = x.Discount,
                DiscountPercent = x.DiscountPercent,
                Picture = x.Picture,
                Price = x.Price,
                ProductName = x.ProductName,
                SecondaryPrice = x.SecondaryPrice,
                Summery = x.Summery
            })
            .ToListAsync();
        return result;
    }

    public async ValueTask<Product?> GetProductByIdAsync(Ulid productId)
        => await _context.Products.FirstOrDefaultAsync(x => x.Id == productId && x.StatusProduct == Status.Show);

    public async ValueTask<Product?> ChangeStatusProductByIdAsync(Status status, Ulid productId)
    {
        try
        {
            var item = await _context.Products!.FindAsync(productId);
            if (item is null) return null;
            item.StatusProduct = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ICollection<Product>?> SearchByItemsAsync(string request)
        => await _context.Products.Where(x => x.Title.Contains(request)).ToListAsync();

    public async ValueTask<Product?> ChangeStateProductAsync(ChangeStateProductCommand request)
    {
        try
        {
            var product = await GetProductByIdAsync(request.Id);
            product!.StatusPublish = request.Status;
            await _context.SaveChangesAsync();
            return product;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Product?> CreateProductAsync(CreateProductCommand request)
    {
        try
        {
            Product item = new()
            {
                ProductName = request.ProductName,
                IdProductCategory = request.ProductCategoryId,
                Title = request.Title,
                Summery = request.Summery,
                Price = request.Price,
                SecondaryPrice = request.SecondaryPrice,
                Discount = request.Discount,
                DiscountPercent = request.DiscountPercent,
                Picture = request.Picture
            };
            await _context.Products.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Product?> UpdateProductAsync(UpdateProductCommand request)
    {
        try
        {
            Product item = new()
            {
                ProductName = request.ProductName,
                IdProductCategory = request.ProductCategoryId,
                Title = request.Title,
                Summery = request.Summery,
                Price = request.Price,
                SecondaryPrice = request.SecondaryPrice,
                Discount = request.Discount,
                DiscountPercent = request.DiscountPercent,
                Picture = request.Picture
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Product?> DeleteProductAsync(DeleteProductCommand request)
    {
        try
        {
            var product = await GetProductByIdAsync(request.Id);
            product!.StatusProduct = Status.Deleted;
            await _context.SaveChangesAsync();
            return product;
        }
        catch
        {
            return null;
        }
    }
}