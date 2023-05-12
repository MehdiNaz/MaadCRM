namespace DataAccess.Repositories.Customers.PeyGiry;

public class CustomerPeyGiryRepository : ICustomerPeyGiryRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    public CustomerPeyGiryRepository(MaadContext context, ILogRepository log)
    {
        _context = context;
        _log = log;
    }

    public async ValueTask<Result<ICollection<CustomerPeyGiryResponse>>> GetAllCustomerPeyGiriesAsync(Ulid customerId)
    {
        try
        {
            return await _context.CustomerPeyGiries
                .Where(x => x.StatusTypeCustomerPeyGiry == StatusType.Show && x.IdCustomer == customerId)
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
            return await _context.CustomerPeyGiries.SingleOrDefaultAsync(x => x.Id == customerPeyGiryId && x.StatusTypeCustomerPeyGiry == StatusType.Show);
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
            item.StatusTypeCustomerPeyGiry = request.CustomerPeyGiryStatusType;
            await _context.SaveChangesAsync();
            return new Result<CustomerPeyGiry>(item);
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
                DatePeyGiry = request.DatePeyGiry,
                IdUserAdded = request.IdUser,
                IdUserUpdated = request.IdUser
            };

            await _context.CustomerPeyGiries.AddAsync(item);

            if (request.DatePeyGiry > DateTime.UtcNow)
            {
                var customerId = (await _context.CustomerPeyGiries.SingleOrDefaultAsync(x => x.Id == item.Id)).IdCustomer;
                (await _context.Customers.SingleOrDefaultAsync(x => x.Id == customerId)).CustomerState = CustomerStateTypes.BelFel;
            }
            await _context.SaveChangesAsync();


            CreateLogCommand command = new()
            {
                PeyGiryId = item.Id,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.InsertPeyGiry,
                UserId = request.IdUser,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            return new Result<CustomerPeyGiry>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerPeyGiry>> UpdateCustomerPeyGiryAsync(UpdateCustomerPeyGiryCommand request)
    {
        try
        {
            CustomerPeyGiry item = await _context.CustomerPeyGiries.FindAsync(request.Id);
            item.Description = request.Description;
            item.DatePeyGiry = request.DatePeyGiry;
            item.IdUserUpdated = request.IdUser;

            _context.Update(item);

            CreateLogCommand command = new()
            {
                PeyGiryId = request.Id,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.UpdatePeyGiry,
                UserId = request.IdUser,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerPeyGiry>> DeleteCustomerPeyGiryAsync(Ulid id)
    {
        try
        {
            var item = await _context.CustomerPeyGiries.FindAsync(id);
            item.StatusTypeCustomerPeyGiry = StatusType.Deleted;
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = id,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.DeletePeyGiry,
                UserId = "request.IdUser",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            return new Result<CustomerPeyGiry>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new ValidationException(e.Message));
        }
    }
}