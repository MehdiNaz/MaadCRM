namespace DataAccess.Repositories.Customers;

public class CustomerCategoryRepository : ICustomerCategoryRepository
{
    private readonly MaadContext _context;

    public CustomerCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CustomerCategory>>> GetAllCustomerCategoryAsync(string userId)
    {
        try
        {
            return await _context.CustomerCategories.Where(x => x.CustomerCategoryStatus == Status.Show && x.UserId == userId).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerCategory>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerCategory>> GetCustomerCategoryByIdAsync(Ulid customerCategoryId, string userId)
    {
        try
        {
            return await _context.CustomerCategories.FirstOrDefaultAsync(x =>
                   x.Id == customerCategoryId
                   && x.CustomerCategoryStatus == Status.Show
                   && x.UserId == userId);
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerCategory>> ChangeStatusCustomerCategoryByIdAsync(ChangeStatusCustomerCategoryCommand request)
    {
        try
        {
            var item = await _context.CustomerCategories.FindAsync(request.Id);
            if (item is null) return null;
            item.CustomerCategoryStatus = request.CustomerCategoryStatus;
            await _context.SaveChangesAsync();
            return new Result<CustomerCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerCategory>> CreateCustomerCategoryAsync(CreateCustomerCategoryCommand request)
    {
        try
        {
            CustomerCategory item = new()
            {
                UserId = request.UserId,
                CustomerCategoryName = request.CustomerCategoryName
            };

            await _context.CustomerCategories.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<CustomerCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerCategory>> UpdateCustomerCategoryAsync(UpdateCustomerCategoryCommand request)
    {
        try
        {
            CustomerCategory item = new()
            {
                Id = request.Id,
                UserId = request.UserId,
                CustomerCategoryName = request.CustomerCategoryName
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerCategory>> DeleteCustomerCategoryAsync(Ulid id)
    {
        try
        {
            var item = await _context.CustomerCategories.FindAsync(id);
            item.CustomerCategoryStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return new Result<CustomerCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new ValidationException(e.Message));
        }
    }
}