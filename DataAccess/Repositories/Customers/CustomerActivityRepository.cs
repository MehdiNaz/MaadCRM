namespace DataAccess.Repositories.Customers;

public class CustomerActivityRepository : ICustomerActivityRepository
{
    private readonly MaadContext _context;

    public CustomerActivityRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerActivity?>> GetAllCustomerActivitiesAsync(Ulid customerId)
        => await _context.CustomerActivities.Where(x => x.CustomerActivityStatus == Status.Show && x.CustomerId == customerId).ToListAsync();

    public async ValueTask<CustomerActivity?> GetCustomerActivityByIdAsync(Ulid customerActivityId)
        => await _context.CustomerActivities.FirstOrDefaultAsync(x => x.CustomerActivityId == customerActivityId && x.CustomerActivityStatus == Status.Show);

    public async ValueTask<CustomerActivity?> ChangeStatusCustomerActivityByIdAsync(Status status, Ulid customerActivityId)
    {
        try
        {
            var item = await _context.CustomerActivities!.FindAsync(customerActivityId);
            if (item is null) return null;
            item.CustomerActivityStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerActivity?> CreateCustomerActivityAsync(CustomerActivity? entity)
    {
        try
        {
            await _context.CustomerActivities!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerActivity?> UpdateCustomerActivityAsync(CustomerActivity entity)
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

    public async ValueTask<CustomerActivity?> DeleteCustomerActivityAsync(Ulid customerActivityId)
    {
        try
        {
            var customerActivity = await GetCustomerActivityByIdAsync(customerActivityId);
            customerActivity!.CustomerActivityStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return customerActivity;
        }
        catch
        {
            return null;
        }
    }
}