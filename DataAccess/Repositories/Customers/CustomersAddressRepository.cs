namespace DataAccess.Repositories.Customers;

public class CustomersAddressRepository : ICustomersAddressRepository
{
    private readonly MaadContext _context;

    public CustomersAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomersAddress?>> GetAllAddressesAsync(Ulid customerId)
        => await _context.CustomersAddresses.Where(x => x.CustomersAddressStatus == Status.Show && x.CustomerId == customerId).ToListAsync();

    public async ValueTask<CustomersAddress?> GetAddressByIdAsync(Ulid customersAddressId)
        => await _context.CustomersAddresses.FirstOrDefaultAsync(x => x.CustomersAddressId == customersAddressId && x.CustomersAddressStatus == Status.Show);

    public async ValueTask<CustomersAddress?> ChangeStatusAddressByIdAsync(Status status, Ulid customersAddressId)
    {
        try
        {
            var item = await _context.CustomersAddresses.FindAsync(customersAddressId);
            if (item is null) return null;
            item.CustomersAddressStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomersAddress?> CreateAddressAsync(CustomersAddress? entity)
    {
        try
        {
            await _context.CustomersAddresses!.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomersAddress?> UpdateAddressAsync(CustomersAddress entity)
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

    public async ValueTask<CustomersAddress?> DeleteAddressAsync(Ulid customersAddressId)
    {
        try
        {
            var customersAddress = await GetAddressByIdAsync(customersAddressId);
            customersAddress.CustomersAddressStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return customersAddress;
        }
        catch
        {
            return null;
        }
    }
}