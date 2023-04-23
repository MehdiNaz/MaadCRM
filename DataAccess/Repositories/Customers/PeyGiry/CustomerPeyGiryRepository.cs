namespace DataAccess.Repositories.Customers.PeyGiry;

public class CustomerPeyGiryRepository : ICustomerPeyGiryRepository
{
    private readonly MaadContext _context;

    public CustomerPeyGiryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CustomerPeyGiryResponse>>> GetAllCustomerPeyGiriesAsync(Ulid customerId)
    {
        try
        {
            return await _context.CustomerPeyGiries
                .Where(x => x.StatusCustomerPeyGiry == Status.Show && x.IdCustomer == customerId)
                .Select(x => new CustomerPeyGiryResponse
                {
                    CustomerPeyGiryId = x.Id,
                    Description = x.Description,
                    DateCreated = x.DateCreated
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerPeyGiryResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerPeyGiry>> GetCustomerPeyGiryByIdAsync(Ulid customerPeyGiryId)
    {
        try
        {
            return await _context.CustomerPeyGiries.SingleOrDefaultAsync(x => x.Id == customerPeyGiryId && x.StatusCustomerPeyGiry == Status.Show);
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerPeyGiry>> ChangeStatusCustomerPeyGiryByIdAsync(ChangeStatusCustomerPeyGiryCommand request)
    {
        try
        {
            var item = await _context.CustomerPeyGiries.FindAsync(request.CustomerPeyGiryId);
            if (item is null) return new Result<CustomerPeyGiry>(new ValidationException());
            item.StatusCustomerPeyGiry = request.CustomerPeyGiryStatus;
            await _context.SaveChangesAsync();
            return new Result<CustomerPeyGiry>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new ValidationException(e.Message));
        }

        try
        {
            var item = await _context.CustomerPeyGiries!.FindAsync(request.CustomerPeyGiryId);
            if (item is null) return new Result<CustomerPeyGiry>(new ValidationException(ResultErrorMessage.NotFound));
            return new Result<CustomerPeyGiry>(new ValidationException());
            item.StatusCustomerPeyGiry = request.CustomerPeyGiryStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new ValidationException(e.Message));
        }
    }


    public async ValueTask<Result<CustomerPeyGiry>> CreateCustomerPeyGiryAsync(CreateCustomerPeyGiryCommand request)
    {
        try
        {
            CustomerPeyGiry item = new()
            {
                Description = request.Description,
                IdCustomer = request.CustomerId,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };
            await _context.CustomerPeyGiries!.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<CustomerPeyGiry>(item);
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Result<CustomerPeyGiry>> UpdateCustomerPeyGiryAsync(UpdateCustomerPeyGiryCommand request)
    {
        try
        {
            CustomerPeyGiry item = new()
            {
                Id = request.Id,
                Description = request.Description,
                IdCustomer = request.CustomerId,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerPeyGiry>> DeleteCustomerPeyGiryAsync(DeleteCustomerPeyGiryCommand request)
    {
        try
        {
            var item = (await _context.CustomerPeyGiries.FirstOrDefaultAsync(x => x.Id == request.Id && x.StatusCustomerPeyGiry == Status.Show));
            item.StatusCustomerPeyGiry = Status.Deleted;
            await _context.SaveChangesAsync();
            return new Result<CustomerPeyGiry>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new ValidationException(e.Message));
        }
    }
}