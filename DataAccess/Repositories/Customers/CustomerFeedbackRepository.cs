namespace DataAccess.Repositories.Customers;

public class CustomerFeedbackRepository : ICustomerFeedbackRepository
{
    private readonly MaadContext _context;

    public CustomerFeedbackRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerFeedback?>> GetAllCustomerFeedbacksAsync()
        => await _context.CustomerFeedbacks.Where(x => x.Status == Status.Show).ToListAsync();


    public async ValueTask<CustomerFeedback?> GetCustomerFeedbackByIdAsync(Ulid customerFeedbackId)
        => await _context.CustomerFeedbacks.FirstOrDefaultAsync(x => x.Id == customerFeedbackId && x.Status == Status.Show);

    public async ValueTask<CustomerFeedback?> ChangeStatusCustomerFeedbackByIdAsync(ChangeStatusCustomerFeedBackCommand request)
    {
        try
        {
            var item = await _context.CustomerFeedbacks.FindAsync(request.Id);
            if (item is null) return null;
            item.Status = request.CustomerFeedbackStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerFeedback?> CreateCustomerFeedbackAsync(CreateCustomerFeedBackCommand request)
    {
        try
        {
            CustomerFeedback item = new()
            {
                Description = request.Description,
            };
            await _context.CustomerFeedbacks!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerFeedback?> UpdateCustomerFeedbackAsync(UpdateCustomerFeedBackCommand request)
    {
        try
        {
            CustomerFeedback item = new()
            {
                Id = request.Id,
                Description = request.Description,
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerFeedback?> DeleteCustomerFeedbackAsync(Ulid id)
    {
        try
        {
            var customerFeedback = await _context.CustomerFeedbacks.FindAsync(id);
            customerFeedback!.Status = Status.Deleted;
            await _context.SaveChangesAsync();
            return customerFeedback;
        }
        catch
        {
            return null;
        }
    }
}