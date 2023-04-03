namespace DataAccess.Repositories.Customers;

public class CustomersAddressRepository : ICustomersAddressRepository
{
    private readonly MaadContext _context;

    public CustomersAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomersAddress?>> GetAllAddressesAsync()
        => (await _context.CustomersAddresses!.ToListAsync()).Where(x => x.IsDeleted == Status.NotDeleted).ToList()!;


    public async ValueTask<CustomersAddress?> GetAddressByIdAsync(Ulid customersAddressId)
        => await _context.CustomersAddresses!.FindAsync(customersAddressId);

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

    public async ValueTask<CustomersAddress?> UpdateAddressAsync(CustomersAddress entity, Ulid customersAddressId)
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
            customersAddress.IsDeleted = Status.Deleted;
            await _context.SaveChangesAsync();
            return customersAddress;
        }
        catch
        {
            return null;
        }
    }
}