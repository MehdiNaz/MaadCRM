namespace DataAccess.Repositories.Customers.Feedback;

public class CustomerFeedbackRepository : ICustomerFeedbackRepository
{
    private readonly MaadContext _context;

    public CustomerFeedbackRepository(MaadContext context)
    {
        _context = context;
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
            return await _context.CustomerFeedbacks.FirstOrDefaultAsync(x => x.Id == feedbackId && x.CustomerFeedbackStatus == Status.Show);
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
            item.CustomerFeedbackStatus = request.CustomerFeedbackStatus;
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
            item.Id= request.Id;
            item.Description = request.Description;
            item.IdCategory = request.IdCategory;
            item.IdProduct = request.IdProduct;
            item.IdCustomer = request.IdCustomer;

            _context.Update(item);
            await _context.SaveChangesAsync();
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
            item.CustomerFeedbackStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return new Result<CustomerFeedback>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new ValidationException(e.Message));
        }
    }
}
