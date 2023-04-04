namespace DataAccess.Repositories.Contacts;

public class ContactPhoneNumberRepository : IContactPhoneNumberRepository
{
    private readonly MaadContext _context;

    public ContactPhoneNumberRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ContactPhoneNumber?>> GetAllContactPhoneNumberAsync()
        => (await _context.ContactPhoneNumbers!.ToListAsync()).Where(x => x.ContactPhoneNumberStatus == Status.Show).ToList()!;

    public async ValueTask<ContactPhoneNumber?> GetContactPhoneNumberByIdAsync(Ulid contactPhoneNumberId) => await _context.ContactPhoneNumbers!.FindAsync(contactPhoneNumberId);

    public async ValueTask<ContactPhoneNumber?> CreateContactPhoneNumberAsync(ContactPhoneNumber? entity)
    {
        try
        {
            await _context.ContactPhoneNumbers!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactPhoneNumber?> UpdateContactPhoneNumberAsync(ContactPhoneNumber entity, Ulid contactPhoneNumberId)
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

    public async ValueTask<ContactPhoneNumber?> DeleteContactPhoneNumberAsync(Ulid contactPhoneNumberId)
    {
        try
        {
            var contactPhoneNumber = await GetContactPhoneNumberByIdAsync(contactPhoneNumberId);
            contactPhoneNumber!.ContactPhoneNumberStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return contactPhoneNumber;
        }
        catch
        {
            return null;
        }
    }
}