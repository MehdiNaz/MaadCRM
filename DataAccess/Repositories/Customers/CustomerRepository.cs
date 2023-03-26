namespace DataAccess.Repositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly MaadContext _context;

    public CustomerRepository(MaadContext aadContext)
    {
        _context = aadContext;
    }

    public async Task<ICollection<Customer?>> GetAllCustomersAsync() => (await _context.Customers!.ToListAsync())!;
    public async ValueTask<Customer?> GetCustomerByIdAsync(int customerId) => await _context.Customers!.FindAsync(customerId);

    public async ValueTask<Customer?> CreateCustomerAsync(Customer? toCreate)
    {
        await _context.Customers!.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<Customer?> UpdateCustomerAsync(string updateContent, int customerId)
    {
        var customer = await GetCustomerByIdAsync(customerId);
        _context.Update(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async ValueTask DeleteCustomerAsync(int customerId)
    {
        var customer = await GetCustomerByIdAsync(customerId);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}