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
        => await _context.CustomerActivities.FirstOrDefaultAsync(x => x.Id == customerActivityId && x.CustomerActivityStatus == Status.Show);

    public async ValueTask<CustomerActivity?> ChangeStatusCustomerActivityByIdAsync(ChangeStatusCustomerActivityCommand request)
    {
        try
        {
            var item = await _context.CustomerActivities!.FindAsync(request.Id);
            if (item is null) return null;
            item.CustomerActivityStatus = request.CustomerActivityStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerActivity?> CreateCustomerActivityAsync(CreateCustomerActivityCommand request)
    {
        try
        {
            CustomerActivity item = new()
            {
                CustomerActivityName = request.CustomerActivityName,
                CustomerActivityDescription = request.CustomerActivityDescription,
                CustomerId = request.CustomerId
            };
            await _context.CustomerActivities!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerActivity?> UpdateCustomerActivityAsync(UpdateCustomerActivityCommand request)
    {
        try
        {
            CustomerActivity item = new()
            {
                Id = request.Id,
                CustomerActivityName = request.CustomerActivityName,
                CustomerActivityDescription = request.CustomerActivityDescription,
                CustomerId = request.CustomerId
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

    public async ValueTask<CustomerActivity?> DeleteCustomerActivityAsync(DeleteCustomerActivityCommand request)
    {
        try
        {
            var customerActivity = await GetCustomerActivityByIdAsync(request.Id);
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