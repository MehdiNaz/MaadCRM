namespace DataAccess.Repositories.Contacts;

public class ContactPhoneNumberRepository : IContactPhoneNumberRepository
{
    private readonly MaadContext _context;

    public ContactPhoneNumberRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ContactPhoneNumber?>> GetAllContactPhoneNumberAsync()
        => await _context.ContactPhoneNumbers.Where(x => x.ContactPhoneNumberStatus == Status.Show).ToListAsync();

    public async ValueTask<ContactPhoneNumber?> GetContactPhoneNumberByIdAsync(Ulid contactPhoneNumberId)
        => await _context.ContactPhoneNumbers.FirstOrDefaultAsync(x =>
            x.ContactPhoneNumberId == contactPhoneNumberId && x.ContactPhoneNumberStatus == Status.Show);

    public async ValueTask<ContactPhoneNumber?> ChangeStatusContactPhoneNumberByIdAsync(Status status, Ulid contactPhoneNumberId)
    {
        try
        {
            var item = await _context.ContactPhoneNumbers!.FindAsync(contactPhoneNumberId);
            if (item is null) return null;
            item.ContactPhoneNumberStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

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