namespace DataAccess.Repositories.Contacts;

public class ContactRepository : IContactRepository
{
    private readonly MaadContext _context;

    public ContactRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<Contact?>> GetAllContactAsync()
        => (await _context.Contacts!.ToListAsync()).Where(x => x.ContactStatus == Status.Show).ToList()!;

    public async ValueTask<Contact?> GetContactByIdAsync(Ulid contactId) => await _context.Contacts!.FindAsync(contactId);

    public async ValueTask<Contact?> CreateContactAsync(Contact? entity)
    {
        try
        {
            await _context.Contacts!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Contact?> UpdateContactAsync(Contact entity, Ulid contactId)
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

    public async ValueTask<Contact?> DeleteContactAsync(Ulid contactId)
    {
        try
        {
            var contact = await GetContactByIdAsync(contactId);
            contact!.ContactStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return contact;
        }
        catch
        {
            return null;
        }
    }
}