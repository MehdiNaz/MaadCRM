using Application.Responses.Product;

namespace DataAccess.Repositories.Products;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    public ProductCategoryRepository(MaadContext context, ILogRepository log)
    {
        _context = context;
        _log = log;
    }

    public async ValueTask<Result<ICollection<ProductCategoryResponse>>> GetAllProductCategoriesAsync(Ulid businessId)
    {
        try
        {
            return await _context.ProductCategories
                .Where(x => x.ProductCategoryStatusType == StatusType.Show)
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
                && x.ProductCategoryStatusType == StatusType.Show)
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
            return await _context.ProductCategories.Where(x => x.Description.ToLower().Contains(request.ToLower())
                                                 || x.ProductCategoryStatusType == StatusType.Show).ToListAsync();
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
            item.ProductCategoryStatusType = request.ProductCategoryStatusType;
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

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = item.Id,
                ForooshId = null,
                Type = LogTypes.InsertCategory,
                UserId = request.IdUserAdded,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            await _context.SaveChangesAsync();
            return await _context.ProductCategories
                 .FirstOrDefaultAsync(x => x.ProductCategoryName == request.ProductCategoryName)
                 .Select(x => new ProductCategoryResponse
                 {
                     Id = x.Id,
                     Name = x.ProductCategoryName
                 });
            //return new Result<ProductCategoryResponse>(new ValidationException("Error"));
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

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = item.Id,
                ForooshId = null,
                Type = LogTypes.UpdateCategory,
                UserId = request.IdUserUpdated,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            await _context.SaveChangesAsync();
            return await _context.ProductCategories
                .FirstOrDefaultAsync(x => x.ProductCategoryName == request.ProductCategoryName)
                .Select(x => new ProductCategoryResponse
                {
                    Id = x.Id,
                    Name = x.ProductCategoryName
                });
            // return new Result<ProductCategoryResponse>(new ValidationException("Error"));
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
            productCategory.ProductCategoryStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = id,
                ForooshId = null,
                Type = LogTypes.InsertCategory,
                UserId = "request.IdUserAdded",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

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