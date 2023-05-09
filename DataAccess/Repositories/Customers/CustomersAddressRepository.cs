namespace DataAccess.Repositories.Customers;

public class CustomersAddressRepository : ICustomersAddressRepository
{
    private readonly MaadContext _context;

    public CustomersAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerAddress?>> GetAllAddressesAsync(Ulid customerId)
    {
        var result = await _context.CustomersAddresses.Where(x => x.StatusTypeCustomersAddress == StatusType.Show && x.IdCustomer == customerId).ToListAsync();
        return result;
    }

    public async ValueTask<CustomerAddress?> GetAddressByIdAsync(Ulid customersAddressId)
        => await _context.CustomersAddresses.FirstOrDefaultAsync(x => x.Id == customersAddressId && x.StatusTypeCustomersAddress == StatusType.Show);

    public async ValueTask<CustomerAddress?> ChangeStatusAddressByIdAsync(ChangeStatusCustomersAddressCommand request)
    {
        try
        {
            var item = await _context.CustomersAddresses.FindAsync(request.Id);
            if (item is null) return null;
            item.StatusTypeCustomersAddress = request.CustomersAddressStatusType;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerAddress?> CreateAddressAsync(CreateCustomersAddressCommand request)
    {
        try
        {
            CustomerAddress item = new()
            {
                Address = request.Address,
                CodePost = request.CodePost,
                PhoneNo = request.PhoneNo,
                Description = request.Description,
                IdCustomer = request.CustomerId
            };
            await _context.CustomersAddresses!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerAddress?> UpdateAddressAsync(UpdateCustomersAddressCommand request)
    {
        try
        {
            CustomerAddress item = await _context.CustomersAddresses.FindAsync(request.Id);
            item.Address = request.Address;
            item.CodePost = request.CodePost;
            item.PhoneNo = request.PhoneNo;
            item.Description = request.Description;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerAddress?> DeleteAddressAsync(Ulid id)
    {
        try
        {
            var customersAddress = await _context.CustomersAddresses.FindAsync(id);
            customersAddress.StatusTypeCustomersAddress = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return customersAddress;
        }
        catch
        {
            return null;
        }
    }
}