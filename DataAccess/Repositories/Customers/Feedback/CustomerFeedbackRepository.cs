using LanguageExt.Pipes;

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

    public async ValueTask<Result<ICollection<CustomerFeedback>>> GetAllCustomerFeedbacksAsync()
    {
        try
        {
            return new Result<ICollection<CustomerFeedback>>(await _context.CustomerFeedbacks.ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedback>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedback>> GetCustomerFeedbackByIdAsync(Ulid feedbackId)
    {
        try
        {
            return await _context.CustomerFeedbacks.FirstOrDefaultAsync(x => x.Id == feedbackId && x.CustomerFeedbackStatusType == StatusType.Show);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<CustomerFeedback>>> SearchByItemsAsync(string request)
    {
        try
        {
            return new Result<ICollection<CustomerFeedback>>
                (await _context.CustomerFeedbacks.Where(x => x.Description.Contains(request)).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedback>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedback>> ChangeStatusCustomerFeedbacksByIdAsync(ChangeStateCustomerFeedbackCommand request)
    {
        try
        {
            CustomerFeedback feedback = new()
            {
                Id = request.Id
            };

            var item = await _context.CustomerFeedbacks.FindAsync(feedback);
            if (item is null) return new Result<CustomerFeedback>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerFeedbackStatusType = request.CustomerFeedbackStatusType;
            await _context.SaveChangesAsync();
            return new Result<CustomerFeedback>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedback>> CreateCustomerFeedbackAsync(CreateCustomerFeedbackCommand request)
    {
        try
        {
            CustomerFeedback item = new()
            {
                Description = request.Description,
                IdCategory = request.IdCategory,
                IdProduct = request.IdProduct,
                IdCustomer = request.IdCustomer
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

            return new Result<CustomerFeedback>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedback>> UpdateCustomerFeedbackAsync(UpdateCustomerFeedbackCommand request)
    {
        try
        {
            CustomerFeedback item = await _context.CustomerFeedbacks.FindAsync(request.Id);
            item.Description = request.Description;

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

            return new Result<CustomerFeedback>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedback>> DeleteCustomerFeedbackAsync(Ulid id)
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

            return new Result<CustomerFeedback>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new ValidationException(e.Message));
        }
    }
}
