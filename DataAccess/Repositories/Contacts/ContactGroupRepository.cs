using Application.Services.ContactGroupService.Queries;

namespace DataAccess.Repositories.Contacts;

public class ContactGroupRepository : IContactGroupRepository
{
    private readonly MaadContext _context;

    public ContactGroupRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ContactGroup>>> GetAllContactGroupsAsync(AllContactGroupsQuery request)
    {
        try
        {
            var user = await _context.Users.FindAsync(request.UserId);
            return user is null ? 
                new Result<ICollection<ContactGroup>>(new ValidationException(ResultErrorMessage.NotFound)) : 
                new Result<ICollection<ContactGroup?>>(
                    await _context.ContactGroups.Where(x => 
                        x.ContactGroupStatusType == StatusType.Show && 
                        x.BusinessId == user.IdBusiness)
                    .ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactGroup?>>(new ValidationException(e.Message))!;
        }
    }

    public async ValueTask<Result<ContactGroup>> GetContactGroupByIdAsync(Ulid contactGroupId)
    {
        try
        {
            return await _context.ContactGroups!.FirstOrDefaultAsync(x => x.Id == contactGroupId && x.ContactGroupStatusType == StatusType.Show);
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
            item.ContactGroupStatusType = request.ContactGroupStatusType;
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
            var result = await _context.ContactGroups.Where(x => x.ContactGroupStatusType == StatusType.Show 
                    && x.GroupName.ToLower().Contains(q.ToLower())).ToListAsync();

            return new Result<ICollection<ContactGroup>>(result);
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactGroup>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ContactGroup>> CreateContactGroupAsync(CreateContactGroupCommand request)
    {
        try
        {
            ContactGroup item = new()
            {
                GroupName = request.GroupName,
                DisplayOrder = request.DisplayOrder,
                BusinessId = request.BusinessId
            };

            await _context.ContactGroups.AddAsync(item!);
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
            ContactGroup item = await _context.ContactGroups.FindAsync(request.Id);
            item.GroupName = request.GroupName;
            item.DisplayOrder = request.DisplayOrder;

            _context.Update(item);
            await _context.SaveChangesAsync();
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
            contactGroup!.ContactGroupStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return new Result<ContactGroup>(contactGroup);
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new ValidationException(e.Message));
        }
    }
}