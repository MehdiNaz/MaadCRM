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
        => await _context.CustomersPhoneNumbers.FirstOrDefaultAsync(x => x.PhoneNumberId == phoneNumberId && x.CustomersPhoneNumberStatus == Status.Show);

    public async ValueTask<CustomersPhoneNumber?> ChangeStatusPhoneNumberByIdAsync(Status status, Ulid phoneNumberId)
    {
        try
        {
            var item = await _context.CustomersPhoneNumbers.FindAsync(phoneNumberId);
            if (item is null) return null;
            item.CustomersPhoneNumberStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

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