namespace DataAccess.Repositories.Customers;

public class CustomersEmailAddressRepository : ICustomersEmailAddressRepository
{
    private readonly MaadContext _context;

    public CustomersEmailAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomersEmailAddress?>> GetAllEmailAddressesAsync()
        => (await _context.CustomersEmailAddresses!.ToListAsync()).Where(x => x.CustomersEmailAddressStatus == Status.Show).ToList()!;

    public async ValueTask<CustomersEmailAddress?> GetEmailAddressByIdAsync(Ulid emailAddressId)
        => await _context.CustomersEmailAddresses!.FindAsync(emailAddressId);

    public async ValueTask<CustomersEmailAddress?> CreateEmailAddressAsync(CustomersEmailAddress? entity)
    {
        try
        {
            await _context.CustomersEmailAddresses!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomersEmailAddress?> UpdateEmailAddressAsync(CustomersEmailAddress entity, Ulid emailAddressId)
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

    public async ValueTask<CustomersEmailAddress?> DeleteEmailAddressAsync(Ulid emailAddressId)
    {
        try
        {
            var customer = await GetEmailAddressByIdAsync(emailAddressId);
            customer!.CustomersEmailAddressStatus = Status.Show;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}