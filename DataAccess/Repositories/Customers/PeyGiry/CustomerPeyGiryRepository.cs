namespace DataAccess.Repositories.Customers.PeyGiry;

public class CustomerPeyGiryRepository : ICustomerPeyGiryRepository
{
    private readonly MaadContext _context;

    public CustomerPeyGiryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerPeyGiryResponse>> GetAllCustomerPeyGiriesAsync(Ulid customerId)
    {
        //IQueryable<Customer> joinList = _context.Customers
        //    .Include(x => x.User)
        //    .Include(x => x.CustomerPeyGiries)
        //    .AsQueryable();
        var A = await _context.CustomerPeyGiries
            .Include(x => x.Customer)
            .Include(x => x.User)
            .Select(x => new CustomerPeyGiryResponse
            {
                Description = x.Description,
                DateCreated = x.DateCreated,
                CustomerPeyGiryId = x.CustomerPeyGiryId,
                Name = x.User.Name + " " + x.User.Family
            }).ToListAsync();
        return A;
    }

    public async ValueTask<CustomerPeyGiry?> GetCustomerPeyGiryByIdAsync(Ulid customerPeyGiryId)
        => await _context.CustomerPeyGiries.SingleOrDefaultAsync(x => x.CustomerPeyGiryId == customerPeyGiryId && x.CustomerPeyGiryStatus == Status.Show);

    public async ValueTask<CustomerPeyGiry?> ChangeStatusCustomerPeyGiryByIdAsync(Status status, Ulid customerPeyGiryId)
    {
        try
        {
            var item = await _context.CustomerPeyGiries!.FindAsync(customerPeyGiryId);
            if (item is null) return null;
            item.CustomerPeyGiryStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }


    public async ValueTask<CustomerPeyGiry?> CreateCustomerPeyGiryAsync(CustomerPeyGiry? entity)
    {
        try
        {
            await _context.CustomerPeyGiries!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerPeyGiry?> UpdateCustomerPeyGiryAsync(CustomerPeyGiry entity)
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

    public async ValueTask<CustomerPeyGiry?> DeleteCustomerPeyGiryAsync(Ulid customerPeyGiryId)
    {
        try
        {
            var customerPeyGiry = await GetCustomerPeyGiryByIdAsync(customerPeyGiryId);
            customerPeyGiry!.CustomerPeyGiryStatus = Status.Show;
            await _context.SaveChangesAsync();
            return customerPeyGiry;
        }
        catch
        {
            return null;
        }
    }
}