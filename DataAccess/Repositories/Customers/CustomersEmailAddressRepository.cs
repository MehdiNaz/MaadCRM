namespace DataAccess.Repositories.Customers;

public class CustomersEmailAddressRepository : ICustomersEmailAddressRepository
{
    private readonly MaadContext _context;

    public CustomersEmailAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomersEmailAddress?>> GetAllEmailAddressesAsync()
        => (await _context.EmailAddresses!.ToListAsync()).Where(x => x.IsDeleted == (byte)Status.NotDeleted).ToList()!;

    public async ValueTask<CustomersEmailAddress?> GetEmailAddressByIdAsync(Ulid emailAddressId)
        => await _context.EmailAddresses!.FindAsync(emailAddressId);

    public async ValueTask<CustomersEmailAddress?> CreateEmailAddressAsync(CustomersEmailAddress? entity)
    {
        try
        {
            await _context.EmailAddresses!.AddAsync(entity!);
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
            customer!.IsDeleted = (byte)Status.Deleted;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}