namespace DataAccess.Repositories.Customers;

public class CustomersEmailAddressRepository : ICustomersEmailAddressRepository
{
    private readonly MaadContext _context;

    public CustomersEmailAddressRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomersEmailAddress?>> GetAllEmailAddressesAsync()
        => await _context.CustomersEmailAddresses.Where(x => x.StatusCustomerEmailAddress == Status.Show).ToListAsync();

    public async ValueTask<CustomersEmailAddress?> GetEmailAddressByIdAsync(Ulid emailAddressId)
        => await _context.CustomersEmailAddresses.FirstOrDefaultAsync(x => x.Id == emailAddressId && x.StatusCustomerEmailAddress == Status.Show);

    public async ValueTask<CustomersEmailAddress?> ChangeStatusEmailAddressByIdAsync(ChangeStatusCustomersEmailAddressCommand request)
    {
        try
        {
            var item = await _context.CustomersEmailAddresses.FindAsync(request.Id);
            if (item is null) return null;
            item.StatusCustomerEmailAddress = request.ContactsEmailAddressStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomersEmailAddress?> CreateEmailAddressAsync(CreateCustomersEmailAddressCommand request)
    {
        try
        {
            CustomersEmailAddress item = new()
            {
                CustomerEmailAddress = request.EmailAddress,
                IdCustomer = request.CustomerId
            };

            await _context.CustomersEmailAddresses!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomersEmailAddress?> UpdateEmailAddressAsync(UpdateCustomersEmailAddressCommand request)
    {
        try
        {
            CustomersEmailAddress item = new()
            {
                Id = request.Id,
                CustomerEmailAddress = request.EmailAddress,
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

    public async ValueTask<CustomersEmailAddress?> DeleteEmailAddressAsync(DeleteCustomersEmailAddressCommand request)
    {
        try
        {
            var customer = await GetEmailAddressByIdAsync(request.Id);
            customer!.StatusCustomerEmailAddress = Status.Show;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}