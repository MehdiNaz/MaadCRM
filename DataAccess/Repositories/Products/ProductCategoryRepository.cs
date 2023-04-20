using Application.Services.ProductCategoryService.Commands;

namespace DataAccess.Repositories.Products;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly MaadContext _context;

    public ProductCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ProductCategory>> GetAllProductCategoriesAsync(Ulid businessId)
    {
        try
        {
            return await _context.ProductCategories
                .Where(x => x.ProductCategoryStatus == Status.Show)
                .Include(x => x.Business).Where(x => x.BusinessId == businessId)
                .ToListAsync();
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ProductCategory?> GetProductCategoryByIdAsync(Ulid businessId)
        => await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == businessId && x.ProductCategoryStatus == Status.Show);

    public async ValueTask<ICollection<ProductCategory>> SearchByItemsAsync(string request)
        => await _context.ProductCategories.Where(x => x.Description.ToLower().Contains(request.ToLower()) && x.ProductCategoryStatus == Status.Show).ToListAsync();

    public async ValueTask<ProductCategory?> ChangeStatusProductCategoryByIdAsync(ChangeStatusProductCategoryCommand request)
    {
        try
        {
            var item = await _context.ProductCategories!.FindAsync(request.Id);
            if (item is null) return null;
            item.ProductCategoryStatus = request.ProductCategoryStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ProductCategory?> CreateProductCategoryAsync(CreateProductCategoryCommand request)
    {
        try
        {
            ProductCategory item = new()
            {
                Order = request.Order,
                ProductCategoryName = request.ProductCategoryName,
                Description = request.Description,
                Icon = request.Icon,
                BusinessId = request.BusinessId
            };
            await _context.ProductCategories!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ProductCategory?> UpdateProductCategoryAsync(UpdateProductCategoryCommand request)
    {
        try
        {
            ProductCategory item = new()
            {
                Id = request.Id,
                Order = request.Order,
                ProductCategoryName = request.ProductCategoryName,
                Description = request.Description,
                Icon = request.Icon,
                BusinessId = request.BusinessId
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

    public async ValueTask<ProductCategory?> DeleteProductCategoryAsync(DeleteProductCategoryCommand request)
    {
        try
        {
            var productCategory = await GetProductCategoryByIdAsync(request.Id);
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