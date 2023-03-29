namespace DataAccess.Repositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly MaadContext _context;

    public CustomerRepository(MaadContext aadContext)
    {
        _context = aadContext;
    }

    public async Task<ICollection<Customer?>> GetAllCustomersAsync()
        => (await _context.Customers!.ToListAsync()).Where(x => x.IsDeleted == Status.NotDeleted).ToList()!;

    public async ValueTask<Customer?> GetCustomerByIdAsync(Ulid customerId) => await _context.Customers!.FindAsync(customerId);

    public async ValueTask<Customer?> CreateCustomerAsync(Customer? entity)
    {
        try
        {
            await _context.Customers!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Customer?> UpdateCustomerAsync(Customer entity, Ulid customerId)
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
            customer!.IsDeleted = Status.Deleted;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}