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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByUserIdAsync(string userId)
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
                .Where(x => x.UserId == userId)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertPeyGiryAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.InsertPeyGiry)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdatePeyGiryAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.UpdatePeyGiry)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeletePeyGiryAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.DeletePeyGiry)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertNoteAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.InsertNote)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateNoteAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.UpdateNote)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteNoteAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.DeleteNote)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertFeedBackAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.InsertFeedBack)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateFeedBackAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.UpdateFeedBack)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteFeedBackAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.DeleteFeedBack)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertCustomerAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.InsertCustomer)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateCustomerAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.UpdateCustomer)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteCustomerAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.DeleteCustomer)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertProductCategoryAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.InsertCategory)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateProductCategoryAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.UpdateCategory)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteProductCategoryAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.DeleteCategory)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertForooshAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.InsertForoosh)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateForooshAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.UpdateForoosh)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteForooshAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.DeleteForoosh)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertProductAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.InsertProduct)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateProductAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.UpdateProduct)
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

    public async ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteProductAsync(LogTypes request)
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
                .Where(x => x.Type == LogTypes.DeleteProduct)
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
                .Select(x => new LogResponse
                {
                    Id = x.Id,
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

    public async ValueTask<Result<LogResponse>> GetByNoteIdAsync(Ulid noteId)
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
                .Include(x => x.ProductCategory)
                .Include(x => x.User)
                .Select(x => new LogResponse
                {
                    Id = x.Id,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductCategoryName = x.ProductCategory.ProductCategoryName,
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

    public async ValueTask<Result<LogResponse>> InsertAsync(CreateLogCommand request)
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
                UserId = request.UserId,
                IpAddress = request.IpAddress,
                UserAgent = request.UserAgent,
                Type = request.Type,
                Description = request.Description
            };

            await _context.Logs.AddAsync(item);

            await _context.SaveChangesAsync();

            return new Result<LogResponse>();
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