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
                CustomerPeyGiryId = x.Id,
                Name = x.User.Name + " " + x.User.Family
            }).ToListAsync();
        return A;
    }

    public async ValueTask<CustomerPeyGiry?> GetCustomerPeyGiryByIdAsync(Ulid customerPeyGiryId)
        => await _context.CustomerPeyGiries.SingleOrDefaultAsync(x => x.Id == customerPeyGiryId && x.CustomerPeyGiryStatus == Status.Show);

    public async ValueTask<CustomerPeyGiry?> ChangeStatusCustomerPeyGiryByIdAsync(ChangeStatusCustomerPeyGiryCommand request)
    {
        try
        {
            var item = await _context.CustomerPeyGiries!.FindAsync(request.CustomerPeyGiryId);
            if (item is null) return null;
            item.CustomerPeyGiryStatus = request.CustomerPeyGiryStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }


    public async ValueTask<CustomerPeyGiry?> CreateCustomerPeyGiryAsync(CreateCustomerPeyGiryCommand request)
    {
        try
        {
            CustomerPeyGiry item = new()
            {
                Description = request.Description,
                CustomerId = request.CustomerId
            };
            await _context.CustomerPeyGiries!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerPeyGiry?> UpdateCustomerPeyGiryAsync(UpdateCustomerPeyGiryCommand request)
    {
        try
        {
            CustomerPeyGiry item = new()
            {
                Id = request.Id,
                Description = request.Description,
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

    public async ValueTask<CustomerPeyGiry?> DeleteCustomerPeyGiryAsync(DeleteCustomerPeyGiryCommand request)
    {
        try
        {
            var customerPeyGiry = await GetCustomerPeyGiryByIdAsync(request.Id);
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