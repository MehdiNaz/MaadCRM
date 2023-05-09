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
            return new Result<ICollection<ContactsResponse>>(await _context.Contacts.Where(x => x.ContactStatusType == StatusType.Show)
                .Include(x => x.ContactsEmailAddresses)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().ContactEmailAddress,
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
            return await _context.Contacts
                .Include(x => x.ContactsEmailAddresses)
                .Include(x => x.ContactPhoneNumbers)
                .FirstOrDefaultAsync(x => x.Id == contactId && x.ContactStatusType == StatusType.Show)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault()?.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault()?.PhoneNo
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
                .Where(x => x.ContactStatusType == StatusType.Show && x.ContactGroupId == contactGroupId)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().ContactEmailAddress,
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
            var resultsListcontact = _context.Contacts.Where(x => x.ContactStatusType == StatusType.Show)
                .Include(x => x.ContactsEmailAddresses)
                .Include(x => x.ContactPhoneNumbers)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault().ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault().PhoneNo
                }).AsQueryable();


            return await resultsListcontact.Where(
                x => x.FirstName.ToLower().Contains(q.ToLower())
                || x.LastName.ToLower().Contains(q.ToLower())).ToListAsync();
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
            item.ContactStatusType = request.ContactStatusType;
            await _context.SaveChangesAsync();
            return await _context.Contacts
            .Include(x => x.ContactsEmailAddresses)
            .Include(x => x.ContactPhoneNumbers)
            .FirstOrDefaultAsync(x => x.Id == request.Id)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault()?.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault()?.PhoneNo
                });
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
                ContactGroupId = request.ContactGroupId,
                Job = request.Job,
                BusinessId = request.BusinessId
            };
            await _context.Contacts.AddAsync(item);
            await _context.SaveChangesAsync();



            foreach (var email in request.EmailAddresses)
            {
                ContactsEmailAddress emailAddress = new()
                {
                    ContactId = item.Id,
                    ContactEmailAddress = email
                };
                await _context.ContactsEmailAddresses.AddAsync(emailAddress);
            }

            foreach (var phone in request.PhoneNumber)
            {
                ContactPhoneNumber phoneNumber = new()
                {
                    ContactId = item.Id,
                    PhoneNo = phone
                };
                await _context.ContactPhoneNumbers.AddAsync(phoneNumber);
            }

            await _context.SaveChangesAsync();

            return await _context.Contacts
                .Include(x => x.ContactsEmailAddresses)
                .Include(x => x.ContactPhoneNumbers)
                .FirstOrDefaultAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault()?.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault()?.PhoneNo
                });
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
            Contact item = await _context.Contacts.FindAsync(request.Id);
            item.Id = request.Id;
            item.FirstName = request.FirstName;
            item.LastName = request.LastName;
            item.EmailId = request.EmailId;
            item.ContactGroupId = request.ContactGroupId;
            item.Job = request.Job;
            item.BusinessId = request.BusinessId;

            _context.Update(item);
            await _context.SaveChangesAsync();


            return await _context.Contacts
            .Include(x => x.ContactsEmailAddresses)
            .Include(x => x.ContactPhoneNumbers)
            .FirstOrDefaultAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName && x.Id == item.Id)
                .Select(x => new ContactsResponse
                {
                    ContactId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses.FirstOrDefault()?.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers.FirstOrDefault()?.PhoneNo
                });
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
            contact.ContactStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return await _context.Contacts
            .Include(x => x.ContactsEmailAddresses)
            .Include(x => x.ContactPhoneNumbers)
            .FirstOrDefaultAsync(x => x.Id == id)
            .Select(x => new ContactsResponse
            {
                ContactId = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Job = x.Job,
                EmailAddress = x.ContactsEmailAddresses.FirstOrDefault()?.ContactEmailAddress,
                MobileNumber = x.ContactPhoneNumbers.FirstOrDefault()?.PhoneNo
            });
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new ValidationException(e.Message));
        }
    }
}