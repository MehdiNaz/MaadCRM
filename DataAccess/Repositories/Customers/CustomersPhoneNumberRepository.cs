namespace DataAccess.Repositories.Customers;

public class CustomersPhoneNumberRepository : ICustomersPhoneNumberRepository
{
    private readonly MaadContext _context;

    public CustomersPhoneNumberRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomersPhoneNumber?>> GetAllPhoneNumbersAsync()
        => await _context.CustomersPhoneNumbers.Where(x => x.CustomersPhoneNumberStatus == Status.Show).ToListAsync();

    public async ValueTask<CustomersPhoneNumber?> GetPhoneNumberByIdAsync(Ulid phoneNumberId)
        => await _context.CustomersPhoneNumbers.FindAsync(phoneNumberId);

    public async ValueTask<CustomersPhoneNumber?> CreatePhoneNumberAsync(CustomersPhoneNumber? entity)
    {
        try
        {
            await _context.CustomersPhoneNumbers!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomersPhoneNumber?> UpdatePhoneNumberAsync(CustomersPhoneNumber entity, Ulid phoneNumberId)
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

    public async ValueTask<CustomersPhoneNumber?> DeletePhoneNumberAsync(Ulid phoneNumberId)
    {
        try
        {
            var phoneNumber = await GetPhoneNumberByIdAsync(phoneNumberId);
            phoneNumber!.CustomersPhoneNumberStatus = Status.Show;
            await _context.SaveChangesAsync();
            return phoneNumber;
        }
        catch
        {
            return null;
        }
    }
}