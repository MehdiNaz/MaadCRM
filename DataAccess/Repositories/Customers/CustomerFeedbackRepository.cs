namespace DataAccess.Repositories.Customers;

public class CustomerFeedbackRepository : ICustomerFeedbackRepository
{
    private readonly MaadContext _context;

    public CustomerFeedbackRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerFeedback?>> GetAllCustomerFeedbacksAsync()
        => await _context.CustomerFeedbacks.Where(x => x.CustomerFeedbackStatus == Status.Show).ToListAsync();


    public async ValueTask<CustomerFeedback?> GetCustomerFeedbackByIdAsync(Ulid customerFeedbackId)
        => await _context.CustomerFeedbacks.FirstOrDefaultAsync(x => x.CustomerFeedbackId == customerFeedbackId && x.CustomerFeedbackStatus == Status.Show);

    public async ValueTask<CustomerFeedback?> ChangeStatusCustomerFeedbackByIdAsync(Status status, Ulid customerFeedbackId)
    {
        try
        {
            var item = await _context.CustomerFeedbacks.FindAsync(customerFeedbackId);
            if (item is null) return null;
            item.CustomerFeedbackStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerFeedback?> CreateCustomerFeedbackAsync(CustomerFeedback? entity)
    {
        try
        {
            await _context.CustomerFeedbacks!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerFeedback?> UpdateCustomerFeedbackAsync(CustomerFeedback entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerFeedback?> DeleteCustomerFeedbackAsync(Ulid customerFeedbackId)
    {
        try
        {
            var customerFeedback = await GetCustomerFeedbackByIdAsync(customerFeedbackId);
            customerFeedback!.CustomerFeedbackStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return customerFeedback;
        }
        catch
        {
            return null;
        }
    }
}