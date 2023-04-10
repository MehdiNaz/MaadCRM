namespace DataAccess.Repositories.Customers;

public class CustomerFeedbackFeedback : ICustomerFeedbackFeedback
{
    private readonly MaadContext _context;

    public CustomerFeedbackFeedback(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerFeedback?>> GetAllCustomerFeedbacksAsync()
        => (await _context.CustomerFeedbacks!.ToListAsync()).Where(x => x.CustomerFeedbackStatus == Status.Show).ToList()!;


    public async ValueTask<CustomerFeedback?> GetCustomerFeedbackByIdAsync(Ulid customerFeedbackId)
        => await _context.CustomerFeedbacks!.FindAsync(customerFeedbackId);

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