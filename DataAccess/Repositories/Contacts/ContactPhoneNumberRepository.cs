namespace DataAccess.Repositories.Contacts;

public class ContactPhoneNumberRepository : IContactPhoneNumberRepository
{
    private readonly MaadContext _context;

    public ContactPhoneNumberRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ContactPhoneNumber?>> GetAllContactPhoneNumberAsync()
        => await _context.ContactPhoneNumbers.Where(x => x.ContactPhoneNumberStatusType == StatusType.Show).ToListAsync();

    public async ValueTask<ContactPhoneNumber?> GetContactPhoneNumberByIdAsync(Ulid contactPhoneNumberId)
        => await _context.ContactPhoneNumbers.FirstOrDefaultAsync(x =>
            x.Id == contactPhoneNumberId && x.ContactPhoneNumberStatusType == StatusType.Show);

    public async ValueTask<ContactPhoneNumber?> ChangeStatusContactPhoneNumberByIdAsync(ChangeStatusContactPhoneNumberCommand request)
    {
        try
        {
            var item = await _context.ContactPhoneNumbers!.FindAsync(request.ContactPhoneNumberId);
            if (item is null) return null;
            item.ContactPhoneNumberStatusType = request.ContactPhoneNumberStatusType;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactPhoneNumber?> CreateContactPhoneNumberAsync(CreateContactPhoneNumberCommand request)
    {
        try
        {
            ContactPhoneNumber item = new()
            {
                PhoneNo = request.PhoneNo,
                CustomerId = request.CustomerId
            };
            await _context.ContactPhoneNumbers!.AddAsync(item!);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactPhoneNumber?> UpdateContactPhoneNumberAsync(UpdateContactPhoneNumberCommand request)
    {
        try
        {
            ContactPhoneNumber item = await _context.ContactPhoneNumbers.FindAsync(request.Id);


            item.PhoneNo = request.PhoneNo;
            item.CustomerId = request.CustomerId;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactPhoneNumber?> DeleteContactPhoneNumberAsync(Ulid id)
    {
        try
        {
            var contactPhoneNumber = await _context.ContactPhoneNumbers.FindAsync(id);
            contactPhoneNumber!.ContactPhoneNumberStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return contactPhoneNumber;
        }
        catch
        {
            return null;
        }
    }
}