namespace DataAccess.Repositories.Contacts;

public class ContactRepository : IContactRepository
{
    private readonly MaadContext _context;

    public ContactRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ContactsResponse>>> GetAllContactAsync()
    {
        try
        {
            return new Result<ICollection<ContactsResponse>>(await _context.Contacts.Where(x => x.ContactStatus == Status.Show)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault().PhoneNo
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactsResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactsResponse>> GetContactByIdAsync(Ulid contactId)
    {
        try
        {
            return await _context.Contacts!.FirstOrDefaultAsync(x => x.Id == contactId && x.ContactStatus == Status.Show)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault().PhoneNo
                });
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<ContactsResponse>>> GetContactByGroupIdAsync(Ulid contactGroupId)
    {
        try
        {
            return new Result<ICollection<ContactsResponse>>(await _context.Contacts
                .Where(x => x.ContactStatus == Status.Show && x.ContactGroupId == contactGroupId)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault().PhoneNo
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactsResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<ContactsResponse>>> SearchContactAsync(string q)
    {
        try
        {
            return await _context.Contacts.Where(x => x.ContactStatus == Status.Show
            && x.FirstName.Contains(q) && x.LastName.Contains(q))
                .Include(x => x.ContactsEmailAddresses)
                .Include(x => x.ContactPhoneNumbers)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault().PhoneNo
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactsResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactsResponse>> ChangeStatusContactByIdAsync(ChangeStatusContactCommand request)
    {
        try
        {
            var item = await _context.Contacts.FindAsync(request.Id);
            if (item is null) return new Result<ContactsResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.ContactStatus = request.ContactStatus;
            await _context.SaveChangesAsync();
            return new Result<ContactsResponse>(await _context.Contacts.FindAsync(request.Id)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault().PhoneNo
                }));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactsResponse>> CreateContactAsync(CreateContactCommand request)
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
            await _context.Contacts.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<ContactsResponse>(await _context.Contacts.SingleOrDefaultAsync(x => x.FirstName == request.FirstName)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault().PhoneNo
                }));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactsResponse>> UpdateContactAsync(UpdateContactCommand request)
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
            return new Result<ContactsResponse>(await _context.Contacts.FindAsync(request.Id)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault().PhoneNo
                }));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactsResponse>> DeleteContactAsync(Ulid id)
    {
        try
        {
            var contact = await _context.Contacts.FindAsync(id);
            contact.ContactStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return new Result<ContactsResponse>(await _context.Contacts.FindAsync(id)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault().PhoneNo
                }));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new ValidationException(e.Message));
        }
    }
}