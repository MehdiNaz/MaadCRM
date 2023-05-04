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

    public async ValueTask<ContactsEmailAddress?> GetContactsEmailAddressByIdAsync(Ulid requestId)
        => await _context.ContactsEmailAddresses!.SingleOrDefaultAsync(x =>
            x.Id == requestId && x.ContactsEmailAddressStatus == Status.Show);

    public async ValueTask<ContactsEmailAddress?> ChangeStatusContactsEmailAddressByIdAsync(ChangeStatusContactEmailAddressCommand request)
    {
        try
        {
            var item = await _context.ContactsEmailAddresses!.FindAsync(request.CustomersEmailAddressId);
            if (item is null) return null;
            item.ContactsEmailAddressStatus = request.ContactsEmailAddressStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }

    }

    public async ValueTask<ContactsEmailAddress?> CreateContactsEmailAddressAsync(CreateContactEmailAddressCommand request)
    {
        try
        {
            ContactsEmailAddress item = new()
            {
                ContactEmailAddress = request.EmailAddress
            };
            await _context.ContactsEmailAddresses!.AddAsync(item!);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactsEmailAddress?> UpdateContactsEmailAddressAsync(UpdateContactEmailAddressCommand request)
    {
        try
        {
            ContactsEmailAddress item = await _context.ContactsEmailAddresses.FindAsync(request.Id);

            item.ContactEmailAddress = request.EmailAddress;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactsEmailAddress?> DeleteContactsEmailAddressAsync(Ulid id)
    {
        try
        {
            var contactsEmailAddress = await _context.ContactsEmailAddresses.FindAsync(id);
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