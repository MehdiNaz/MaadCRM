namespace DataAccess.Repositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly MaadContext _context;

    public CustomerRepository(MaadContext aadContext)
    {
        _context = aadContext;
    }

    public async ValueTask<ICollection<Customer?>> GetAllCustomersAsync()
        => await _context.Customers.Where(x => x.CustomerStatus == Status.Show).ToListAsync();

    public async ValueTask<Customer?> GetCustomerByIdAsync(Ulid customerId) => await _context.Customers!.FindAsync(customerId);

    public async ValueTask<Customer?> CreateCustomerAsync(Customer? entity)
    {
        try
        {
            await _context.Customers!.AddAsync(entity!);
            return await _context.SaveChangesAsync() != 0 ? entity : null;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Customer?> UpdateCustomerAsync(Customer entity)
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

    public async ValueTask<Customer?> DeleteCustomerAsync(Ulid customerId)
    {
        try
        {
            var customer = await GetCustomerByIdAsync(customerId);
            customer!.CustomerStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}