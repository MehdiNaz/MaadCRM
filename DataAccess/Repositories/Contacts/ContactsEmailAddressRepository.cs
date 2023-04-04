namespace DataAccess.Repositories.Contacts;

public class ContactsEmailAddressRepository : IContactsEmailAddressRepository
{
    private readonly MaadContext _context;

    public ContactsEmailAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ContactsEmailAddress?>> GetAllContactsEmailAddressAsync()
        => (await _context.ContactsEmailAddresses!.ToListAsync()).Where(x => x.ContactsEmailAddressStatus == Status.Show).ToList()!;

    public async ValueTask<ContactsEmailAddress?> GetContactsEmailAddressByIdAsync(Ulid contactsEmailAddressId) => await _context.ContactsEmailAddresses!.FindAsync(contactsEmailAddressId);


    public async ValueTask<ContactsEmailAddress?> CreateContactsEmailAddressAsync(ContactsEmailAddress? entity)
    {
        try
        {
            await _context.ContactsEmailAddresses!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactsEmailAddress?> UpdateContactsEmailAddressAsync(ContactsEmailAddress entity, Ulid contactsEmailAddressId)
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

    public async ValueTask<ContactsEmailAddress?> DeleteContactsEmailAddressAsync(Ulid contactsEmailAddressId)
    {
        try
        {
            var contactsEmailAddress = await GetContactsEmailAddressByIdAsync(contactsEmailAddressId);
            contactsEmailAddress!.ContactsEmailAddressStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return contactsEmailAddress;
        }
        catch
        {
            return null;
        }
    }
}