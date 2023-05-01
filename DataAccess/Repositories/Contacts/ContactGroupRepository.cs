namespace DataAccess.Repositories.Contacts;

public class ContactGroupRepository : IContactGroupRepository
{
    private readonly MaadContext _context;

    public ContactGroupRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ContactGroup>>> GetAllContactGroupsAsync()
    {
        try
        {
            return new Result<ICollection<ContactGroup?>>(await _context.ContactGroups.Where(x => x.ContactGroupStatus == Status.Show).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactGroup?>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactGroup>> GetContactGroupByIdAsync(Ulid contactGroupId)
    {
        try
        {
            return await _context.ContactGroups!.FirstOrDefaultAsync(x => x.Id == contactGroupId && x.ContactGroupStatus == Status.Show);
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactGroup>> ChangeStatusContactGroupAsync(ChangeStatusContactGroupCommand request)
    {
        try
        {
            var item = await _context.ContactGroups!.FindAsync(request.ContactGroupId);
            if (item is null) return new Result<ContactGroup>(new ValidationException(ResultErrorMessage.NotFound)); ;
            item.ContactGroupStatus = request.ContactGroupStatus;
            await _context.SaveChangesAsync();
            return new Result<ContactGroup>(item);
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<ContactGroup>>> SearchContactGroupAsync(string q)
    {
        try
        {
            return new Result<ICollection<ContactGroup>>(await _context.ContactGroups
                .Where(x => x.ContactGroupStatus == Status.Show
                 && x.GroupName.Contains(q)).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactGroup?>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactGroup>> CreateContactGroupAsync(CreateContactGroupCommand request)
    {
        try
        {
            ContactGroup item = new()
            {
                GroupName = request.GroupName,
                DisplayOrder = request.DisplayOrder
            };
            await _context.ContactGroups!.AddAsync(item!);
            await _context.SaveChangesAsync();
            return new Result<ContactGroup>(item);
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactGroup>> UpdateContactGroupAsync(UpdateContactGroupCommand request)
    {
        try
        {
            ContactGroup item = new()
            {
                Id = request.Id,
                GroupName = request.GroupName,
                DisplayOrder = request.DisplayOrder
            };

            _context.Update(item); await _context.SaveChangesAsync();
            return new Result<ContactGroup>(item);
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactGroup>> DeleteContactGroupAsync(Ulid id)
    {
        try
        {
            var contactGroup = await _context.ContactGroups.FindAsync(id);
            contactGroup!.ContactGroupStatus = Status.Show;
            await _context.SaveChangesAsync();
            return new Result<ContactGroup>(contactGroup);
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new ValidationException(e.Message));
        }
    }
}