namespace DataAccess.Repositories.Customers;

public class CustomerCategoryRepository : ICustomerCategoryRepository
{
    private readonly MaadContext _context;

    public CustomerCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CustomerFeedbackCategory>>> GetAllCustomerCategoryAsync(string userId)
    {
        try
        {
            return await _context.CustomerCategories.Where(x => x.Status == Status.Show && x.IdUser == userId).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategory>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> GetCustomerCategoryByIdAsync(Ulid customerCategoryId, string userId)
    {
        try
        {
            return await _context.CustomerCategories.FirstOrDefaultAsync(x =>
                   x.Id == customerCategoryId
                   && x.Status == Status.Show
                   && x.IdUser == userId);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> ChangeStatusCustomerCategoryByIdAsync(ChangeStatusCustomerCategoryCommand request)
    {
        try
        {
            var item = await _context.CustomerCategories.FindAsync(request.Id);
            if (item is null) return null;
            item.Status = request.CustomerCategoryStatus;
            await _context.SaveChangesAsync();
            return new Result<CustomerFeedbackCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> CreateCustomerCategoryAsync(CreateCustomerCategoryCommand request)
    {
        try
        {
            CustomerFeedbackCategory item = new()
            {
                IdUser = request.UserId,
                Name = request.CustomerCategoryName
            };

            await _context.CustomerCategories.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<CustomerFeedbackCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> UpdateCustomerCategoryAsync(UpdateCustomerCategoryCommand request)
    {
        try
        {
            CustomerFeedbackCategory item = new()
            {
                Id = request.Id,
                IdUser = request.UserId,
                Name = request.CustomerCategoryName
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> DeleteCustomerCategoryAsync(Ulid id)
    {
        try
        {
            var item = await _context.CustomerCategories.FindAsync(id);
            item.Status = Status.Deleted;
            await _context.SaveChangesAsync();
            return new Result<CustomerFeedbackCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }
    }
}