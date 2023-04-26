namespace DataAccess.Repositories.Contacts;

public class ContactGroupRepository : IContactGroupRepository
{
    private readonly MaadContext _context;

    public ContactGroupRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ContactGroup?>> GetAllContactGroupsAsync()
    => await _context.ContactGroups.Where(x => x.ContactGroupStatus == Status.Show).ToListAsync();

    public async ValueTask<ContactGroup?> GetContactGroupByIdAsync(Ulid contactGroupId)
        => await _context.ContactGroups!.FirstOrDefaultAsync(x => x.Id == contactGroupId && x.ContactGroupStatus == Status.Show);

    public async ValueTask<ContactGroup?> ChangeStatusContactGroupAsync(ChangeStatusContactGroupCommand request)
    {
        try
        {
            var item = await _context.ContactGroups!.FindAsync(request.ContactGroupId);
            if (item is null) return null;
            item.ContactGroupStatus = request.ContactGroupStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactGroup?> CreateContactGroupAsync(CreateContactGroupCommand request)
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
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactGroup?> UpdateContactGroupAsync(UpdateContactGroupCommand request)
    {
        try
        {
            ContactGroup item = new()
            {
                Id = request.Id,
                GroupName = request.GroupName,
                DisplayOrder = request.DisplayOrder
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

    public async ValueTask<ContactGroup?> DeleteContactGroupAsync(Ulid id)
    {
        try
        {
            var contactGroup = await _context.ContactGroups.FindAsync(id);
            contactGroup!.ContactGroupStatus = Status.Show;
            await _context.SaveChangesAsync();
            return contactGroup;
        }
        catch
        {
            return null;
        }
    }
}