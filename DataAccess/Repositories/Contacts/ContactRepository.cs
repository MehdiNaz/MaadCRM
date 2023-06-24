namespace DataAccess.Repositories.Contacts;

public class ContactRepository : IContactRepository
{
    private readonly MaadContext _context;
    public ContactRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ContactsResponse>>> GetAllContactAsync(AllContactQuery request)
    {
        try
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user is null) return new Result<ICollection<ContactsResponse>>(new ValidationException(ResultErrorMessage.NotFound));
            
            return new Result<ICollection<ContactsResponse>>(await _context.Contacts
                .Where(x => x.ContactStatusType == StatusType.Show && x.BusinessId == user.IdBusiness)
                .Select(x => new ContactsResponse
                {
                    IdContact = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses!.FirstOrDefault()!.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    IdContactGroup = x.ContactGroup.Id,
                    ContactGroupName = x.ContactGroup.GroupName
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
            return new Result<ContactsResponse>(await _context.Contacts
                .Select(x => new ContactsResponse
                {
                    IdContact = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses!.FirstOrDefault()!.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    IdContactGroup = x.ContactGroup.Id,
                    ContactGroupName = x.ContactGroup.GroupName,
                    Status = x.ContactStatusType
                }).FirstOrDefaultAsync(x => x.IdContact == contactId && x.Status == StatusType.Show));
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
                .Include(x => x.ContactGroup)
                .Where(x => x.ContactStatusType == StatusType.Show && x.ContactGroupId == contactGroupId)
                .Select(x => new ContactsResponse
                {
                    IdContact = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses!.FirstOrDefault()!.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    IdContactGroup = x.ContactGroup.Id,
                    ContactGroupName = x.ContactGroup.GroupName
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactsResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<ContactsResponse>>> SearchContactAsync(ContactBySearchItemQuery request)
    {
        try
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user is null) return new Result<ICollection<ContactsResponse>>(new ValidationException(ResultErrorMessage.NotFound));

            return new Result<ICollection<ContactsResponse>>(await _context.Contacts
                // .Include(x => x.ContactsEmailAddresses)
                // .Include(x => x.ContactPhoneNumbers)
                // .Include(x => x.ContactGroup)
                .Where(x => 
                    x.BusinessId == user.IdBusiness &&
                    x.ContactStatusType == StatusType.Show &&
                    x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo.Contains(request.Q) ||
                    (x.FirstName + " " + x.LastName).ToLower().Contains(request.Q.ToLower()) &&
                    x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo.ToLower().Contains(request.Q.ToLower()) ||
                    x.ContactsEmailAddresses!.FirstOrDefault()!.ContactEmailAddress.ToLower()
                                .Contains(request.Q.ToLower()))
                .Select(x => new ContactsResponse
                {
                    IdContact = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses!.FirstOrDefault()!.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    IdContactGroup = x.ContactGroup.Id,
                    ContactGroupName = x.ContactGroup.GroupName
                }).ToListAsync());
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
            return new Result<ContactsResponse>(await _context.Contacts
                .Include(x => x.ContactsEmailAddresses)
                .Include(x => x.ContactPhoneNumbers)
                .Include(x => x.ContactGroup)
                .Select(x => new ContactsResponse
                {
                    IdContact = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses!.FirstOrDefault()!.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    IdContactGroup = x.ContactGroup.Id,
                    ContactGroupName = x.ContactGroup.GroupName,
                    Status = x.ContactStatusType
                }).FirstOrDefaultAsync(x => x.IdContact == request.Id && x.Status == StatusType.Show));
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
            var user = await _context.Users.FindAsync(request.IdUser);
            if (user is null) return new Result<ContactsResponse>(new ValidationException(ResultErrorMessage.NotFound));
            
            if (await _context.Contacts.AnyAsync(x => x.ContactPhoneNumbers!.Any(xx => xx.PhoneNo == request.PhoneNumber.FirstOrDefault() && x.BusinessId == user.IdBusiness)))
                return new Result<ContactsResponse>(new ValidationException("این مخاطب قبلا ثبت شده است"));

            Contact item = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactGroupId = request.ContactGroupId,
                Job = request.Job,
                BusinessId = user.IdBusiness,
            };
            await _context.Contacts.AddAsync(item);
            await _context.SaveChangesAsync();


            if (request.EmailAddresses is not null)
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

            return new Result<ContactsResponse>(await _context.Contacts
                .Select(x => new ContactsResponse
                {
                    IdContact = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses!.FirstOrDefault()!.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    IdContactGroup = x.ContactGroup.Id,
                    ContactGroupName = x.ContactGroup.GroupName,
                    Status = x.ContactStatusType
                }).FirstOrDefaultAsync(x => x.IdContact == item.Id));
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
            var item = await _context.Contacts.FindAsync(request.Id);
            if (item == null)
                return new Result<ContactsResponse>(new ValidationException("مخاطبی با این مشخصات یافت نشد"));
            
            item.Id = request.Id;
            item.FirstName = request.FirstName;
            item.LastName = request.LastName;
            item.EmailId = request.EmailId;
            item.ContactGroupId = request.ContactGroupId;
            item.Job = request.Job;
            item.BusinessId = request.BusinessId;

            _context.Update(item);
            await _context.SaveChangesAsync();


            return new Result<ContactsResponse>(await _context.Contacts
                .Include(x => x.ContactsEmailAddresses)
                .Include(x => x.ContactPhoneNumbers)
                .Include(x => x.ContactGroup)
                .Select(x => new ContactsResponse
                {
                    IdContact = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses!.FirstOrDefault()!.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    IdContactGroup = x.ContactGroup.Id,
                    ContactGroupName = x.ContactGroup.GroupName,
                    Status = x.ContactStatusType
                })
                .FirstOrDefaultAsync(x => x.IdContact == item.Id));

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
            if (contact == null)
                return new Result<ContactsResponse>(new ValidationException("مخاطبی با این مشخصات یافت نشد"));
                
            contact.ContactStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return new Result<ContactsResponse>(await _context.Contacts
                .Include(x => x.ContactsEmailAddresses)
                .Include(x => x.ContactPhoneNumbers)
                .Include(x => x.ContactGroup)
                .Select(x => new ContactsResponse
                {
                    IdContact = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    EmailAddress = x.ContactsEmailAddresses!.FirstOrDefault()!.ContactEmailAddress,
                    MobileNumber = x.ContactPhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    IdContactGroup = x.ContactGroup.Id,
                    ContactGroupName = x.ContactGroup.GroupName
                })
                .FirstOrDefaultAsync(x => x.IdContact == id));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new ValidationException(e.Message));
        }
    }
}