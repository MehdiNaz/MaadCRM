namespace DataAccess.Repositories.Products;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly MaadContext _context;

    public ProductCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ProductCategory>>> GetAllProductCategoriesAsync(Ulid businessId)
    {
        try
        {
            return await _context.ProductCategories
                .Where(x => x.ProductCategoryStatus == Status.Show)
                .Where(x => x.BusinessId == businessId)
                .ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductCategory>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductCategory>> GetProductCategoryByIdAsync(Ulid productCategoryId)
    {
        try
        {
            return await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategoryId && x.ProductCategoryStatus == Status.Show);
        }
        catch (Exception e)
        {
            return new Result<ProductCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<ProductCategory>>> SearchByItemsAsync(string request)
    {
        try
        {
            return await _context.ProductCategories.Where(x => x.Description.ToLower().Contains(request.ToLower()) && x.ProductCategoryStatus == Status.Show).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductCategory>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductCategory>> ChangeStatusProductCategoryByIdAsync(ChangeStatusProductCategoryCommand request)
    {
        try
        {
            var item = await _context.ProductCategories!.FindAsync(request.Id);
            if (item is null) return null;
            item.ProductCategoryStatus = request.ProductCategoryStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<ProductCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductCategory>> CreateProductCategoryAsync(CreateProductCategoryCommand request)
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
        catch (Exception e)
        {
            return new Result<ProductCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductCategory>> UpdateProductCategoryAsync(UpdateProductCategoryCommand request)
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
        catch (Exception e)
        {
            return new Result<ProductCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductCategory>> DeleteProductCategoryAsync(DeleteProductCategoryCommand request)
    {
        try
        {
            var productCategory = await _context.ProductCategories.FindAsync(request.Id);
            productCategory.ProductCategoryStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return productCategory;
        }
        catch (Exception e)
        {
            return new Result<ProductCategory>(new ValidationException(e.Message));
        }
    }
}