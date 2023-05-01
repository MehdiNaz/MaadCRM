namespace DataAccess.Repositories.Contacts;

public class ContactRepository : IContactRepository
{
    private readonly MaadContext _context;

    public ContactRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<Contact>>> GetAllContactAsync()
    {
        try
        {
            return new Result<ICollection<Contact>>(await _context.Contacts.Where(x => x.ContactStatus == Status.Show).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<Contact>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Contact>> GetContactByIdAsync(Ulid contactId)
    {
        try
        {
            return await _context.Contacts!.FirstOrDefaultAsync(x => x.Id == contactId && x.ContactStatus == Status.Show);
        }
        catch (Exception e)
        {
            return new Result<Contact>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Contact>> ChangeStatusContactByIdAsync(ChangeStatusContactCommand request)
    {
        try
        {
            var item = await _context.Contacts!.FindAsync(request.Id);
            if (item is null) return new Result<Contact>(new ValidationException(ResultErrorMessage.NotFound));
            item.ContactStatus = request.ContactStatus;
            await _context.SaveChangesAsync();
            return new Result<Contact>(item);
        }
        catch (Exception e)
        {
            return new Result<Contact>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Contact>> CreateContactAsync(CreateContactCommand request)
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
            await _context.Contacts.AddAsync(item!); await _context.SaveChangesAsync();
            return new Result<Contact>(item);
        }
        catch (Exception e)
        {
            return new Result<Contact>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Contact>> UpdateContactAsync(UpdateContactCommand request)
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
            return new Result<Contact>(item);
        }
        catch (Exception e)
        {
            return new Result<Contact>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Contact>> DeleteContactAsync(Ulid id)
    {
        try
        {
            var contact = await _context.Contacts.FindAsync(id);
            contact!.ContactStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return new Result<Contact>(contact);
        }
        catch (Exception e)
        {
            return new Result<Contact>(new ValidationException(e.Message));
        }
    }
}