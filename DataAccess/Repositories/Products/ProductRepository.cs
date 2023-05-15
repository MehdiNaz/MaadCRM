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
                    IdProduct = x.Id,
                    IdProductCategory = x.ProductCategory.Id,
                    Title = x.Title,
                    CategoryName = x.ProductCategory.ProductCategoryName,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    Picture = x.Picture,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    SecondaryPrice = x.SecondaryPrice,
                    Summery = x.Summery
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductResponse>> GetProductByIdAsync(Ulid productId)
    {
        try
        {
            return await _context.Products
                .Include(x => x.ProductCategory)
                .FirstOrDefaultAsync(x => x.Id == productId && x.StatusTypeProduct == StatusType.Show)
                .Select(x => new ProductResponse
                {
                    IdProduct = x.Id,
                    IdProductCategory = x.ProductCategory.Id,
                    Title = x.Title,
                    CategoryName = x.ProductCategory.ProductCategoryName,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    Picture = x.Picture,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    SecondaryPrice = x.SecondaryPrice,
                    Summery = x.Summery
                });
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<ProductResponse>>> GetProductByIdCategoryAsync(Ulid categoryId)
    {
        try
        {
            return await _context.Products
                .Include(x => x.ProductCategory)
                .Where(x => x.IdProductCategory == categoryId && x.StatusTypeProduct == StatusType.Show)
                .Select(x => new ProductResponse
                {
                    IdProduct = x.Id,
                    IdProductCategory = x.ProductCategory.Id,
                    Title = x.Title,
                    CategoryName = x.ProductCategory.ProductCategoryName,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    Picture = x.Picture,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    SecondaryPrice = x.SecondaryPrice,
                    Summery = x.Summery
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductResponse>> ChangeStatusProductByIdAsync(StatusType statusType, Ulid productId)
    {
        try
        {
            var item = await _context.Products.FindAsync(productId);
            if (item is null) return new Result<ProductResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.StatusTypeProduct = statusType;
            await _context.SaveChangesAsync();
            return await _context.Products
                  .Include(x => x.ProductCategory)
                  .FirstOrDefaultAsync(x => x.Id == productId && x.StatusTypeProduct == StatusType.Show)
                  .Select(x => new ProductResponse
                  {
                      IdProduct = x.Id,
                      IdProductCategory = x.ProductCategory.Id,
                      Title = x.Title,
                      CategoryName = x.ProductCategory.ProductCategoryName,
                      Discount = x.Discount,
                      DiscountPercent = x.DiscountPercent,
                      Picture = x.Picture,
                      Price = x.Price,
                      ProductName = x.ProductName,
                      SecondaryPrice = x.SecondaryPrice,
                      Summery = x.Summery
                  });
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<ProductResponse>>> SearchByItemsAsync(string request)
    {
        try
        {
            return await _context.Products.Where(x => x.Title.ToLower().Contains(request.ToLower()) && x.StatusTypeProduct == StatusType.Show)
                .Include(x => x.ProductCategory)
                .Select(x => new ProductResponse
                {
                    IdProduct = x.Id,
                    IdProductCategory = x.ProductCategory.Id,
                    Title = x.Title,
                    CategoryName = x.ProductCategory.ProductCategoryName,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    Picture = x.Picture,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    SecondaryPrice = x.SecondaryPrice,
                    Summery = x.Summery
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductResponse>> ChangeStatusProductAsync(ChangeStateProductCommand request)
    {
        try
        {
            var item = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id && x.StatusTypeProduct == StatusType.Show);
            item.StatusPublish = request.Status;
            await _context.SaveChangesAsync();
            return await _context.Products
                .Include(x => x.ProductCategory)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.StatusTypeProduct == StatusType.Show)
                .Select(x => new ProductResponse
                {
                    IdProduct = x.Id,
                    IdProductCategory = x.ProductCategory.Id,
                    Title = x.Title,
                    CategoryName = x.ProductCategory.ProductCategoryName,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    Picture = x.Picture,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    SecondaryPrice = x.SecondaryPrice,
                    Summery = x.Summery
                });
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductResponse>> CreateProductAsync(CreateProductCommand request)
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


            await _context.SaveChangesAsync();


            return await _context.Products
                .Include(x => x.ProductCategory)
                .FirstOrDefaultAsync(x => x.Id == item.Id && x.StatusTypeProduct == StatusType.Show)
                .Select(x => new ProductResponse
                {
                    IdProduct = x.Id,
                    IdProductCategory = x.ProductCategory.Id,
                    Title = x.Title,
                    CategoryName = x.ProductCategory.ProductCategoryName,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    Picture = x.Picture,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    SecondaryPrice = x.SecondaryPrice,
                    Summery = x.Summery
                });
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductResponse>> UpdateProductAsync(UpdateProductCommand request)
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

            return await _context.Products
                .Include(x => x.ProductCategory)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.StatusTypeProduct == StatusType.Show)
                .Select(x => new ProductResponse
                {
                    IdProduct = x.Id,
                    IdProductCategory = x.ProductCategory.Id,
                    Title = x.Title,
                    CategoryName = x.ProductCategory.ProductCategoryName,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    Picture = x.Picture,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    SecondaryPrice = x.SecondaryPrice,
                    Summery = x.Summery
                });
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProductResponse>> DeleteProductAsync(Ulid id)
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

            return await _context.Products
                .Include(x => x.ProductCategory)
                .FirstOrDefaultAsync(x => x.Id == id)
                .Select(x => new ProductResponse
                {
                    IdProduct = x.Id,
                    IdProductCategory = x.ProductCategory.Id,
                    Title = x.Title,
                    CategoryName = x.ProductCategory.ProductCategoryName,
                    Discount = x.Discount,
                    DiscountPercent = x.DiscountPercent,
                    Picture = x.Picture,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    SecondaryPrice = x.SecondaryPrice,
                    Summery = x.Summery
                });
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new ValidationException(e.Message));
        }
    }
}