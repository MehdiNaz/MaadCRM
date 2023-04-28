namespace DataAccess.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly MaadContext _context;

    public ProductRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ProductResponse>>> GetAllProductsAsync(Ulid businessId)
    {
        try
        {
            return await _context.Products.Where(x => x.StatusProduct == Status.Show)
                .Include(c => c.ProductCategoryIdNavigation)
                .Where(x => x.ProductCategoryIdNavigation.BusinessId == businessId)
                .Select(x => new ProductResponse
                {
                    ProductId = x.Id,
                    ProductCategoryId = x.ProductCategoryIdNavigation.Id,
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
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Product>> GetProductByIdAsync(Ulid productId)
    {
        try
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId && x.StatusProduct == Status.Show);
            return result;
        }
        catch (Exception e)
        {
            return new Result<Product>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Product>> ChangeStatusProductByIdAsync(Status status, Ulid productId)
    {
        try
        {
            var item = await _context.Products.FindAsync(productId);
            if (item is null) new Result<Product>(new ValidationException(ResultErrorMessage.NotFound));
            item.StatusProduct = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<Product>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<Product>>> SearchByItemsAsync(string request)
    {
        try
        {
            return await _context.Products.Where(x => x.Title.ToLower().Contains(request.ToLower()) && x.StatusProduct == Status.Show).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<Product>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Product>> ChangeStatusProductAsync(ChangeStateProductCommand request)
    {
        try
        {
            var item = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id && x.StatusProduct == Status.Show);
            item.StatusPublish = request.Status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<Product>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Product>> CreateProductAsync(CreateProductCommand request)
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
        catch (Exception e)
        {
            return new Result<Product>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Product>> UpdateProductAsync(UpdateProductCommand request)
    {
        try
        {
            Product item = new()
            {
                Id = request.Id,
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
        catch (Exception e)
        {
            return new Result<Product>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Product>> DeleteProductAsync(Ulid id)
    {
        try
        {
            var item = await _context.Products.FindAsync(id);
            item.StatusProduct = Status.Deleted;
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<Product>(new ValidationException(e.Message));
        }
    }
}