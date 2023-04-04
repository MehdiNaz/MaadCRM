namespace DataAccess.Repositories.Contacts;

public class ContactGroupRepository : IContactGroupRepository
{
    private readonly MaadContext _context;

    public ContactGroupRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ContactGroup?>> GetAllContactGroupsAsync()
    => (await _context.ContactGroups!.ToListAsync()).Where(x => x.ContactGroupStatus == Status.Show).ToList()!;

    public async ValueTask<ContactGroup?> GetContactGroupByIdAsync(Ulid contactGroupId) => await _context.ContactGroups!.FindAsync(contactGroupId);

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