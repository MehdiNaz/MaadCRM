namespace DataAccess.Repositories.Products;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly MaadContext _context;

    public ProductCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ProductCategory?>> GetAllProductCategoriesAsync()
        => await _context.ProductCategories.Where(x => x.ProductCategoryStatus == Status.Show).ToListAsync();

    public async ValueTask<ProductCategory?> GetProductCategoryByIdAsync(Ulid productCategoryId)
        => await _context.ProductCategories.FirstOrDefaultAsync(x => x.ProductCategoryId == productCategoryId && x.ProductCategoryStatus == Status.Show);

    public async ValueTask<ProductCategory?> ChangeStatusProductCategoryByIdAsync(Status status, Ulid productCategoryId)
    {
        try
        {
            var item = await _context.ProductCategories!.FindAsync(productCategoryId);
            if (item is null) return null;
            item.ProductCategoryStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ProductCategory?> CreateProductCategoryAsync(ProductCategory? entity)
    {
        try
        {
            await _context.ProductCategories!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ProductCategory?> UpdateProductCategoryAsync(ProductCategory entity, Ulid productCategoryId)
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

    public async ValueTask<ProductCategory?> DeleteProductCategoryAsync(Ulid productCategoryId)
    {
        try
        {
            var productCategory = await GetProductCategoryByIdAsync(productCategoryId);
            productCategory!.ProductCategoryStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return productCategory;
        }
        catch
        {
            return null;
        }
    }
}