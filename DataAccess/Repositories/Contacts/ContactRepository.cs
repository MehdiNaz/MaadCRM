namespace DataAccess.Repositories.Contacts;

public class ContactRepository : IContactRepository
{
    private readonly MaadContext _context;

    public ContactRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<Contact?>> GetAllContactAsync()
        => await _context.Contacts.Where(x => x.ContactStatus == Status.Show).ToListAsync();

    public async ValueTask<Contact?> GetContactByIdAsync(Ulid contactId)
        => await _context.Contacts!.FirstOrDefaultAsync(x => x.Id == contactId && x.ContactStatus == Status.Show);

    public async ValueTask<Contact?> ChangeStatusContactByIdAsync(ChangeStatusContactCommand request)
    {
        try
        {
            var item = await _context.Contacts!.FindAsync(request.Id);
            if (item is null) return null;
            item.ContactStatus = request.ContactStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Contact?> CreateContactAsync(CreateContactCommand request)
    {
        try
        {
            Contact item = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailId = request.EmailId,
                ContactGroupId = request.ContactGroupId,
                Job = request.Job,
                BusinessId = request.BusinessId
            };
            await _context.Contacts!.AddAsync(item!);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Contact?> UpdateContactAsync(UpdateContactCommand request)
    {
        try
        {
            Contact item = new()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailId = request.EmailId,
                ContactGroupId = request.ContactGroupId,
                Job = request.Job,
                BusinessId = request.BusinessId
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

    public async ValueTask<Contact?> DeleteContactAsync(DeleteContactCommand request)
    {
        try
        {
            var contact = await GetContactByIdAsync(request.ContactId);
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