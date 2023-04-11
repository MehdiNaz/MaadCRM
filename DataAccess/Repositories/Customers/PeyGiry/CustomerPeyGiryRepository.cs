namespace DataAccess.Repositories.Customers.PeyGiry;

public class CustomerPeyGiryRepository : ICustomerPeyGiryRepository
{
    private readonly MaadContext _context;

    public CustomerPeyGiryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerPeyGiry?>> GetAllCustomerPeyGiriesAsync(Ulid customerId)
        => await _context.CustomerPeyGiries.Where(x => x.CustomerPeyGiryStatus == Status.Show && x.CustomerId == customerId).ToListAsync();

    public async ValueTask<CustomerPeyGiry?> GetCustomerPeyGiryByIdAsync(Ulid customerPeyGiryId)
        => await _context.CustomerPeyGiries.FindAsync(customerPeyGiryId);


    public async ValueTask<CustomerPeyGiry?> CreateCustomerPeyGiryAsync(CustomerPeyGiry? entity)
    {
        try
        {
            await _context.CustomerPeyGiries!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerPeyGiry?> UpdateCustomerPeyGiryAsync(CustomerPeyGiry entity)
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

    public async ValueTask<CustomerPeyGiry?> DeleteCustomerPeyGiryAsync(Ulid customerPeyGiryId)
    {
        try
        {
            var customerPeyGiry = await GetCustomerPeyGiryByIdAsync(customerPeyGiryId);
            customerPeyGiry!.CustomerPeyGiryStatus = Status.Show;
            await _context.SaveChangesAsync();
            return customerPeyGiry;
        }
        catch
        {
            return null;
        }
    }
}