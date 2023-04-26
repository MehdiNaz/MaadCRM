namespace DataAccess.Repositories.Customers;

public class CustomersPhoneNumberRepository : ICustomersPhoneNumberRepository
{
    private readonly MaadContext _context;

    public CustomersPhoneNumberRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomersPhoneNumber?>> GetAllPhoneNumbersAsync()
        => await _context.CustomersPhoneNumbers.Where(x => x.StatusCustomersPhoneNumber == Status.Show).ToListAsync();

    public async ValueTask<CustomersPhoneNumber?> GetPhoneNumberByIdAsync(Ulid phoneNumberId)
        => await _context.CustomersPhoneNumbers.FirstOrDefaultAsync(x => x.Id == phoneNumberId && x.StatusCustomersPhoneNumber == Status.Show);

    public async ValueTask<CustomersPhoneNumber?> ChangeStatusPhoneNumberByIdAsync(ChangeStatusCustomerPhoneNumberCommand request)
    {
        try
        {
            var item = await _context.CustomersPhoneNumbers.FindAsync(request.Id);
            if (item is null) return null;
            item.StatusCustomersPhoneNumber = request.ContactPhoneNumberStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomersPhoneNumber?> CreatePhoneNumberAsync(CreateCustomerPhoneNumberCommand request)
    {
        try
        {
            CustomersPhoneNumber item = new()
            {
                PhoneNo = request.PhoneNo,
                IdCustomer = request.CustomerId,
                PhoneType = PhoneTypes.Phone
            };
            await _context.CustomersPhoneNumbers!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomersPhoneNumber?> UpdatePhoneNumberAsync(UpdateCustomerPhoneNumberCommand request)
    {
        try
        {
            CustomersPhoneNumber item = new()
            {
                Id = request.Id,
                PhoneNo = request.PhoneNo,
                IdCustomer = request.CustomerId,
                PhoneType = PhoneTypes.Phone
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

    public async ValueTask<CustomersPhoneNumber?> DeletePhoneNumberAsync(Ulid id)
    {
        try
        {
            var phoneNumber = await _context.CustomersPhoneNumbers.FindAsync(id);
            phoneNumber!.StatusCustomersPhoneNumber = Status.Show;
            await _context.SaveChangesAsync();
            return phoneNumber;
        }
        catch
        {
            return null;
        }
    }
}