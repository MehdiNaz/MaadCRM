namespace DataAccess.Repositories.Contacts;

public class ContactEmailAddressRepository : IContactsEmailAddressRepository
{
    private readonly MaadContext _context;

    public ContactEmailAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ContactsEmailAddress?>> GetAllContactsEmailAddressAsync()
        => await _context.ContactsEmailAddresses.Where(x => x.ContactsEmailAddressStatus == Status.Show).ToListAsync();

    public async ValueTask<ContactsEmailAddress?> GetContactsEmailAddressByIdAsync(Ulid contactsEmailAddressId)
        => await _context.ContactsEmailAddresses!.SingleOrDefaultAsync(x =>
            x.CustomersEmailAddressId == contactsEmailAddressId && x.ContactsEmailAddressStatus == Status.Show);

    public async ValueTask<ContactsEmailAddress?> ChangeStatusContactsEmailAddressByIdAsync(Status status, Ulid contactsEmailAddressId)
    {
        try
        {
            var item = await _context.ContactsEmailAddresses!.FindAsync(contactsEmailAddressId);
            if (item is null) return null;
            item.ContactsEmailAddressStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }

    }

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