namespace DataAccess.Repositories.Customers;

public class PhoneNumberRepository : IPhoneNumberRepository
{
    private readonly MaadContext _context;

    public PhoneNumberRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<PhoneNumber?>> GetAllPhoneNumbersAsync() => (await _context.PhoneNumbers!.ToListAsync())!;

    public async ValueTask<PhoneNumber?> GetPhoneNumberByIdAsync(Ulid phoneNumberId) => await _context.PhoneNumbers!.FindAsync(phoneNumberId);

    public async ValueTask<PhoneNumber?> CreatePhoneNumberAsync(PhoneNumber? entity)
    {
        try
        {
            await _context.PhoneNumbers!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<PhoneNumber?> UpdatePhoneNumberAsync(PhoneNumber entity, Ulid phoneNumberId)
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

    public async ValueTask<PhoneNumber?> DeletePhoneNumberAsync(Ulid phoneNumberId)
    {
        try
        {
            var phoneNumber = await GetPhoneNumberByIdAsync(phoneNumberId);
            phoneNumber!.IsDeleted = (byte)Status.Deleted;
            await _context.SaveChangesAsync();
            return phoneNumber;
        }
        catch
        {
            return null;
        }
    }
}