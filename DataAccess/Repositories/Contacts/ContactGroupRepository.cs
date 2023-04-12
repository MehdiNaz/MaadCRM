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
        => await _context.ContactGroups!.FirstOrDefaultAsync(x => x.ContactGroupId == contactGroupId && x.ContactGroupStatus == Status.Show);

    public async ValueTask<ContactGroup?> ChangeStateContactGroupAsync(Status status, Ulid contactGroupId)
    {
        try
        {
            var item = await _context.ContactGroups!.FindAsync(contactGroupId);
            if (item is null) return null;
            item.ContactGroupStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactGroup?> CreateContactGroupAsync(ContactGroup? entity)
    {
        try
        {
            await _context.ContactGroups!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactGroup?> UpdateContactGroupAsync(ContactGroup entity, Ulid contactGroupId)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<ContactGroup?> DeleteContactGroupAsync(Ulid contactGroupId)
    {
        try
        {
            var contactGroup = await GetContactGroupByIdAsync(contactGroupId);
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