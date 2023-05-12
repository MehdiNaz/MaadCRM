namespace DataAccess.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    public ProductRepository(MaadContext context, ILogRepository log)
    {
        _context = context;
        _log = log;
    }

    public async ValueTask<Result<ICollection<ProductResponse>>> GetAllProductsAsync(Ulid businessId)
    {
        try
        {
            return await _context.Products.Where(x => x.StatusTypeProduct == StatusType.Show)
                .Include(c => c.ProductCategory)
                .Where(x => x.ProductCategory.BusinessId == businessId)
                .Select(x => new ProductResponse
                {
                    ProductId = x.Id,
                    ProductCategoryId = x.ProductCategory.Id,
                    Title = x.Title,
                    CategoryName = x.ProductCategory.ProductCategoryName,
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
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId && x.StatusTypeProduct == StatusType.Show);
            return result;
        }
        catch (Exception e)
        {
            return new Result<Product>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Product>> ChangeStatusProductByIdAsync(StatusType statusType, Ulid productId)
    {
        try
        {
            var item = await _context.Products.FindAsync(productId);
            if (item is null) return new Result<Product>(new ValidationException(ResultErrorMessage.NotFound));
            item.StatusTypeProduct = statusType;
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
            return await _context.Products.Where(x => x.Title.ToLower().Contains(request.ToLower()) && x.StatusTypeProduct == StatusType.Show).ToListAsync();
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
            var item = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id && x.StatusTypeProduct == StatusType.Show);
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
                Picture = request.Picture,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };

            await _context.Products.AddAsync(item);
            await _context.SaveChangesAsync();


            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = item.Id,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.InsertProduct,
                UserId = request.IdUserAdded,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

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
            Product item = await _context.Products.FindAsync(request.Id);
            item.Id = request.Id;
            item.ProductName = request.ProductName;
            item.Title = request.Title;
            item.Summery = request.Summery;
            item.Price = request.Price;
            item.SecondaryPrice = request.SecondaryPrice;
            item.Discount = request.Discount;
            item.DiscountPercent = request.DiscountPercent;
            item.Picture = request.Picture;
            item.IdUserUpdated = request.IdUserUpdated;

            _context.Update(item);
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = request.Id,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.UpdateProduct,
                UserId = request.IdUserUpdated,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

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
            item.StatusTypeProduct = StatusType.Deleted;
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = id,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.DeleteProduct,
                UserId = "request.IdUserAdded",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            return item;
        }
        catch (Exception e)
        {
            return new Result<Product>(new ValidationException(e.Message));
        }
    }
}