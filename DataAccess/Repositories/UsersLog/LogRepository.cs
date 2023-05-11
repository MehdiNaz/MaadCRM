namespace DataAccess.Repositories.UsersLog;

public class LogRepository : ILogRepository
{
    private readonly MaadContext _context;

    public LogRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<LogResponse>>> GetAllLogsAsync()
    {
        try
        {
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> GetByLogIdAsync(Ulid logId)
    {
        try
        {
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).FirstOrDefaultAsync(x => x.Id == logId);
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> GetByPeyGiryIdAsync(Ulid peyGiryId)
    {
        try
        {
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).FirstOrDefaultAsync(x => x.PeyGiryId == peyGiryId);
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> GetByPeyNoteIdAsync(Ulid noteId)
    {
        try
        {
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).FirstOrDefaultAsync(x => x.NoteId == noteId);
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> GetByCustomerIdAsync(Ulid customerId)
    {
        try
        {
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> GetByProductIdAsync(Ulid productId)
    {
        try
        {
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).FirstOrDefaultAsync(x => x.ProductId == productId);
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> GetByProductCategoryIdAsync(Ulid productCategoryId)
    {
        try
        {
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).FirstOrDefaultAsync(x => x.ProductCategoryId == productCategoryId);
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> GetByForooshIdAsync(Ulid forooshId)
    {
        try
        {
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).FirstOrDefaultAsync(x => x.ForooshId == forooshId);
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> CreateLogAsync(CreateLogCommand request)
    {
        try
        {
            Log item = new()
            {
                PeyGiryId = request.PeyGiryId,
                NoteId = request.NoteId,
                FeedBackId = request.FeedBackId,
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                ProductCategoryId = request.ProductCategoryId,
                ForooshId = request.ForooshId,
                Type = request.Type,
                UserId = request.UserId,
                IpAddress = request.IpAddress,
                UserAgent = request.UserAgent,
                Description = request.Description
            };
            await _context.Logs.AddAsync(item);
            if (await _context.SaveChangesAsync() != 0)
            {
                await _context.Logs
                    .Include(x => x.PeyGiry)
                    .Include(x => x.Note)
                    .Include(x => x.Feedback)
                    .Include(x => x.Customer)
                    .Include(x => x.Product)
                    .Include(x => x.ProductCategory)
                    .Include(x => x.ForooshFactor)
                    .Include(x => x.User)
                    .Select(x => new LogResponse
                    {
                        Id = x.Id,
                        PeyGiryId = x.PeyGiryId,
                        PeyGiryDescription = x.PeyGiry.Description,
                        NoteId = x.NoteId,
                        NoteDescription = x.Note.Description,
                        FeedBackId = x.FeedBackId,
                        FeedBackDescription = x.Feedback.Description,
                        CustomerId = x.CustomerId,
                        CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                        ProductId = x.ProductId,
                        ProductName = x.Product.ProductName,
                        ProductCategoryId = x.ProductCategoryId,
                        ProductCategoryName = x.ProductCategory.ProductCategoryName,
                        ForooshId = x.ForooshId,
                        ForooshAmount = x.ForooshFactor.Amount,
                        Type = x.Type,
                        UserId = x.UserId,
                        UserFullName = x.User.Name + " " + x.User.Family,
                        IpAddress = x.IpAddress,
                        UserAgent = x.UserAgent,
                        Description = x.Description
                    }).FirstOrDefaultAsync(x => x.Id == item.Id);
            }
            return new Result<LogResponse>(new ValidationException("Error"));
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> UpdateLogAsync(UpdateLogCommand request)
    {
        try
        {
            Log item = await _context.Logs.FindAsync(request.Id);
            item.PeyGiryId = request.PeyGiryId;
            item.NoteId = request.NoteId;
            item.FeedBackId = request.FeedBackId;
            item.CustomerId = request.CustomerId;
            item.ProductId = request.ProductId;
            item.ProductCategoryId = request.ProductCategoryId;
            item.ForooshId = request.ForooshId;
            item.Type = request.Type;
            item.UserId = request.UserId;
            item.IpAddress = request.IpAddress;
            item.UserAgent = request.UserAgent;
            item.Description = request.Description;

            await _context.SaveChangesAsync();
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).FirstOrDefaultAsync(x => x.Id == request.Id);
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<LogResponse>> DeleteLogAsync(Ulid id)
    {
        try
        {
            var log = await _context.Logs.FindAsync(id);

            _context.Logs.Remove(log);

            await _context.SaveChangesAsync();
            return await _context.Logs
                .Include(x => x.PeyGiry)
                .Include(x => x.Note)
                .Include(x => x.Feedback)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.ProductCategory)
                .Include(x => x.ForooshFactor)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    PeyGiryId = x.PeyGiryId,
                    PeyGiryDescription = x.PeyGiry.Description,
                    NoteId = x.NoteId,
                    NoteDescription = x.Note.Description,
                    FeedBackId = x.FeedBackId,
                    FeedBackDescription = x.Feedback.Description,
                    CustomerId = x.CustomerId,
                    CustomerFullName = x.Customer.FirstName + " " + x.Customer.LastName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
                    ForooshId = x.ForooshId,
                    ForooshAmount = x.ForooshFactor.Amount,
                    Type = x.Type,
                    UserId = x.UserId,
                    UserFullName = x.User.Name + " " + x.User.Family,
                    IpAddress = x.IpAddress,
                    UserAgent = x.UserAgent,
                    Description = x.Description
                }).FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new ValidationException(e.Message));
        }
    }
}