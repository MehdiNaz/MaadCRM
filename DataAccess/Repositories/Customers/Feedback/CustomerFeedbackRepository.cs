namespace DataAccess.Repositories.Customers.Feedback;

public class CustomerFeedbackRepository : ICustomerFeedbackRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    public CustomerFeedbackRepository(MaadContext context, ILogRepository log)
    {
        _context = context;
        _log = log;
    }

    public async ValueTask<Result<ICollection<CustomerFeedbackResponse>>> GetAllCustomerFeedbacksAsync()
    {
        try
        {
            return new Result<ICollection<CustomerFeedbackResponse>>(await _context.CustomerFeedbacks
                .Where(x => x.CustomerFeedbackStatusType == StatusType.Show)
                .Include(x => x.IdUserNavigation)
                .Select(x => new CustomerFeedbackResponse
                {
                    Id = x.Id,
                    CustomerFeedbackStatusType = x.CustomerFeedbackStatusType,
                    Description = x.Description,
                    IdCustomer = x.IdCustomer,
                    IdCategory = x.IdCategory,
                    IdProduct = x.IdProduct,
                    IdUserAdded = x.IdUser,
                    IdUserUpdated = x.IdUser,
                    IdUser = x.IdUser,
                    UserFullName = x.IdUserNavigation.Name + " " + x.IdUserNavigation.Family
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackResponse>> GetCustomerFeedbackByIdAsync(Ulid feedbackId)
    {
        try
        {
            return await _context.CustomerFeedbacks
                .Include(x => x.IdUserNavigation)
                .Include(x => x.IdProductNavigation)
                .FirstOrDefaultAsync(x => x.Id == feedbackId && x.CustomerFeedbackStatusType == StatusType.Show)
                .Select(x => new CustomerFeedbackResponse
                {
                    Id = x!.Id,
                    CustomerFeedbackStatusType = x.CustomerFeedbackStatusType,
                    Description = x.Description,
                    IdCustomer = x.IdCustomer,
                    IdCategory = x.IdCategory,
                    IdProduct = x.IdProduct,
                    IdUserAdded = x.IdUser,
                    IdUserUpdated = x.IdUser,
                    IdUser = x.IdUser,
                    UserFullName = x.IdUserNavigation?.Name + " " + x.IdUserNavigation?.Family
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<CustomerFeedbackResponse>>> SearchByItemsAsync(string request)
    {
        try
        {
            return new Result<ICollection<CustomerFeedbackResponse>>
            (await _context.CustomerFeedbacks
                .Include(x => x.IdUserNavigation)
                .Where(x => x.Description.Contains(request))
                .Select(x => new CustomerFeedbackResponse
                {
                    Id = x.Id,
                    CustomerFeedbackStatusType = x.CustomerFeedbackStatusType,
                    Description = x.Description,
                    IdCustomer = x.IdCustomer,
                    IdCategory = x.IdCategory,
                    IdProduct = x.IdProduct,
                    IdUserAdded = x.IdUser,
                    IdUserUpdated = x.IdUser,
                    IdUser = x.IdUser,
                    UserFullName = x.IdUserNavigation.Name + " " + x.IdUserNavigation.Family
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackResponse>> ChangeStatusCustomerFeedbacksByIdAsync(ChangeStateCustomerFeedbackCommand request)
    {
        try
        {
            var item = await _context.CustomerFeedbacks.FindAsync(request.Id);
            if (item is null) return new Result<CustomerFeedbackResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerFeedbackStatusType = request.CustomerFeedbackStatusType;
            await _context.SaveChangesAsync();
            return await GetCustomerFeedbackByIdAsync(request.Id);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackResponse>> CreateCustomerFeedbackAsync(CreateCustomerFeedbackCommand request)
    {
        try
        {
            CustomerFeedback item = new()
            {
                Description = request.Description,
                IdCategory = request.IdCategory,
                IdProduct = request.IdProduct,
                IdCustomer = request.IdCustomer,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated,
                IdUser = request.IdUser
            };
            await _context.CustomerFeedbacks.AddAsync(item);
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = item.Id,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.InsertFeedBack,
                UserId = "request.IdUserAdded",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            return await GetCustomerFeedbackByIdAsync(item.Id);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackResponse>> UpdateCustomerFeedbackAsync(UpdateCustomerFeedbackCommand request)
    {
        try
        {
            CustomerFeedback item = await _context.CustomerFeedbacks.FindAsync(request.Id);
            item.Description = request.Description;
            item.IdUser = request.IdUser;

            _context.Update(item);
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = request.Id,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.UpdateFeedBack,
                UserId = "request.IdUserAdded",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);
            return await GetCustomerFeedbackByIdAsync(request.Id);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<string> DeleteCustomerFeedbackAsync(Ulid id)
    {
        try
        {
            var item = await _context.CustomerFeedbacks.FindAsync(id);
            item.CustomerFeedbackStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = id,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.DeleteFeedBack,
                UserId = "request.IdUser",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);
            return "Customer Feedback Deleted.";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}
