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
            x.Id == contactPhoneNumberId && x.ContactPhoneNumberStatus == Status.Show);

    public async ValueTask<ContactPhoneNumber?> ChangeStatusContactPhoneNumberByIdAsync(ChangeStatusContactPhoneNumberCommand request)
    {
        try
        {
            var item = await _context.ContactPhoneNumbers!.FindAsync(request.ContactPhoneNumberId);
            if (item is null) return null;
            item.ContactPhoneNumberStatus = request.ContactPhoneNumberStatus;
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
            ContactPhoneNumber item = new()
            {
                Id = request.Id,
                PhoneNo = request.PhoneNo,
                CustomerId = request.CustomerId
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactPhoneNumber?> DeleteContactPhoneNumberAsync(DeleteContactPhoneNumberCommand request)
    {
        try
        {
            var contactPhoneNumber = await GetContactPhoneNumberByIdAsync(request.Id);
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