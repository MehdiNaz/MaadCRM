namespace DataAccess.Repositories.Products;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly MaadContext _context;

    public ProductCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ProductCategoryResponse>>> GetAllProductCategoriesAsync(Ulid businessId)
    {
        try
        {
            return await _context.ProductCategories
                .Where(x => x.ProductCategoryStatus == Status.Show)
                .Where(x => x.BusinessId == businessId)
                .Select(x => new ProductCategoryResponse
                {
                    Id = x.Id,
                    Name = x.ProductCategoryName
                })
                .ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductCategoryResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductCategoryResponse>> GetProductCategoryByIdAsync(Ulid productCategoryId, Ulid businessId)
    {
        try
        {
            return await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategoryId
                                                                             && x.BusinessId == businessId
                                                                             && x.ProductCategoryStatus == Status.Show)
                .Select(x => new ProductCategoryResponse
                {
                    Id = x.Id,
                    Name = x.ProductCategoryName
                });
        }
        catch (Exception e)
        {
            return new Result<ProductCategoryResponse>(new ValidationException(e.Message));
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
            var item = await _context.ProductCategories.FindAsync(request.Id);
            if (item is null) return new Result<ProductCategory>(new ValidationException(ResultErrorMessage.NotFound));
            item.ProductCategoryStatus = request.ProductCategoryStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<ProductCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductCategoryResponse>> CreateProductCategoryAsync(CreateProductCategoryCommand request)
    {
        try
        {
            ProductCategory item = new()
            {
                Order = request.Order,
                ProductCategoryName = request.ProductCategoryName,
                Description = request.Description,
                Icon = request.Icon,
                BusinessId = request.BusinessId,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };
            await _context.ProductCategories.AddAsync(item);
            if (await _context.SaveChangesAsync() != 0)
            {
                return await _context.ProductCategories
                     .FirstOrDefaultAsync(x => x.ProductCategoryName == request.ProductCategoryName)
                     .Select(x => new ProductCategoryResponse
                     {
                         Id = x.Id,
                         Name = x.ProductCategoryName
                     });
            }
            return new Result<ProductCategoryResponse>(new ValidationException("Error"));
        }
        catch (Exception e)
        {
            return new Result<ProductCategoryResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductCategoryResponse>> UpdateProductCategoryAsync(UpdateProductCategoryCommand request)
    {
        try
        {
            ProductCategory item = await _context.ProductCategories.FindAsync(request.Id);
            item.Order = request.Order;
            item.ProductCategoryName = request.ProductCategoryName;
            item.Description = request.Description;
            item.Icon = request.Icon;
            item.BusinessId = request.BusinessId;
            item.IdUserUpdated = request.IdUserUpdated;


            _context.Update(item);
            if (await _context.SaveChangesAsync() != 0)
            {
                return await _context.ProductCategories
                    .FirstOrDefaultAsync(x => x.ProductCategoryName == request.ProductCategoryName)
                    .Select(x => new ProductCategoryResponse
                    {
                        Id = x.Id,
                        Name = x.ProductCategoryName
                    });
            }
            return new Result<ProductCategoryResponse>(new ValidationException("Error"));
        }
        catch (Exception e)
        {
            return new Result<ProductCategoryResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductCategoryResponse>> DeleteProductCategoryAsync(Ulid id)
    {
        try
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            productCategory.ProductCategoryStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return await _context.ProductCategories
                .FindAsync(id)
                .Select(x => new ProductCategoryResponse
                {
                    Id = x.Id,
                    Name = x.ProductCategoryName
                });
        }
        catch (Exception e)
        {
            return new Result<ProductCategoryResponse>(new ValidationException(e.Message));
        }
    }
}