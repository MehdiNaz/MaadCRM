namespace DataAccess.Repositories.Customers;

public class CustomersAddressRepository : ICustomersAddressRepository
{
    private readonly MaadContext _context;

    public CustomersAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerAddress?>> GetAllAddressesAsync(Ulid customerId)
        => await _context.CustomersAddresses.Where(x => x.StatusCustomersAddress == Status.Show && x.IdCustomer == customerId).ToListAsync();

    public async ValueTask<CustomerAddress?> GetAddressByIdAsync(Ulid customersAddressId)
        => await _context.CustomersAddresses.FirstOrDefaultAsync(x => x.Id == customersAddressId && x.StatusCustomersAddress == Status.Show);

    public async ValueTask<CustomerAddress?> ChangeStatusAddressByIdAsync(ChangeStatusCustomersAddressCommand request)
    {
        try
        {
            var item = await _context.CustomersAddresses.FindAsync(request.Id);
            if (item is null) return null;
            item.StatusCustomersAddress = request.CustomersAddressStatus;
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
            CustomerAddress item = new()
            {
                Id = request.Id,
                Address = request.Address,
                CodePost = request.CodePost,
                PhoneNo = request.PhoneNo,
                Description = request.Description,
                IdCustomer = request.CustomerId
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

    public async ValueTask<CustomerAddress?> DeleteAddressAsync(Ulid id)
    {
        try
        {
            var customersAddress = await _context.CustomersAddresses.FindAsync(id);
            customersAddress.StatusCustomersAddress = Status.Deleted;
            await _context.SaveChangesAsync();
            return customersAddress;
        }
        catch
        {
            return null;
        }
    }
}