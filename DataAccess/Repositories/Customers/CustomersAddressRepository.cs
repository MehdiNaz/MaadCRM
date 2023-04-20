namespace DataAccess.Repositories.Customers;

public class CustomersAddressRepository : ICustomersAddressRepository
{
    private readonly MaadContext _context;

    public CustomersAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomersAddress?>> GetAllAddressesAsync(Ulid customerId)
        => await _context.CustomersAddresses.Where(x => x.CustomersAddressStatus == Status.Show && x.CustomerId == customerId).ToListAsync();

    public async ValueTask<CustomersAddress?> GetAddressByIdAsync(Ulid customersAddressId)
        => await _context.CustomersAddresses.FirstOrDefaultAsync(x => x.Id == customersAddressId && x.CustomersAddressStatus == Status.Show);

    public async ValueTask<CustomersAddress?> ChangeStatusAddressByIdAsync(ChangeStatusCustomersAddressCommand request)
    {
        try
        {
            var item = await _context.CustomersAddresses.FindAsync(request.Id);
            if (item is null) return null;
            item.CustomersAddressStatus = request.CustomersAddressStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomersAddress?> CreateAddressAsync(CreateCustomersAddressCommand request)
    {
        try
        {
            CustomersAddress item = new()
            {
                Address = request.Address,
                CodePost = request.CodePost,
                PhoneNo = request.PhoneNo,
                Description = request.Description,
                CustomerId = request.CustomerId
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

    public async ValueTask<CustomersAddress?> UpdateAddressAsync(UpdateCustomersAddressCommand request)
    {
        try
        {
            CustomersAddress item = new()
            {
                Id = request.Id,
                Address = request.Address,
                CodePost = request.CodePost,
                PhoneNo = request.PhoneNo,
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

    public async ValueTask<CustomersAddress?> DeleteAddressAsync(DeleteCustomersAddressCommand request)
    {
        try
        {
            var customersAddress = await GetAddressByIdAsync(request.Id);
            customersAddress.CustomersAddressStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return customersAddress;
        }
        catch
        {
            return null;
        }
    }
}