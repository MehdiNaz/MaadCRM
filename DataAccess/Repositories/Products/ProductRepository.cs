namespace DataAccess.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly MaadContext _context;

    public ProductRepository(MaadContext context)
    {
        _context = context;
    }

    // Ok
    public async ValueTask<ICollection<Product>> GetAllProductsAsync(Ulid businessId)
    {
        var result= await _context.Products.Where(x => x.ProductStatus == Status.Show)
            .Include(x => x.ProductCategory)
            .ThenInclude(x => x.Business)
            .Where(x => x.ProductCategory.BusinessId == businessId)
            .ToListAsync();
        return result;
    }

    // Ok
    public async ValueTask<Product?> GetProductByIdAsync(Ulid productId)
        => await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId && x.ProductStatus == Status.Show);

    // Ok
    public async ValueTask<Product?> ChangeStatusProductByIdAsync(Status status, Ulid productId)
    {
        try
        {
            var item = await _context.Products!.FindAsync(productId);
            if (item is null) return null;
            item.ProductStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    // Ok
    public async ValueTask<ICollection<Product>?> SearchByItemsAsync(string request)
        => await _context.Products.Where(x => x.Title.Contains(request)).ToListAsync();

    // Ok
    public async ValueTask<Product?> ChangeStateProductAsync(ProductStatus status, Ulid productId)
    {
        try
        {
            var product = await GetProductByIdAsync(productId);
            product!.PublishStatus = status;
            await _context.SaveChangesAsync();
            return product;
        }
        catch
        {
            return null;
        }
    }

    // Ok
    public async ValueTask<Product?> CreateProductAsync(Product? entity)
    {
        try
        {
            await _context.Products!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    // Ok
    public async ValueTask<Product?> UpdateProductAsync(Product entity, Ulid productId)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Product?> DeleteProductAsync(Ulid productId)
    {
        try
        {
            var product = await GetProductByIdAsync(productId);
            product!.ProductStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return product;
        }
        catch
        {
            return null;
        }
    }
}