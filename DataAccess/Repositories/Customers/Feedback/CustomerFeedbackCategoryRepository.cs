namespace DataAccess.Repositories.Customers.Feedback;

public class CustomerFeedbackCategoryRepository : ICustomerFeedbackCategoryRepository
{
    private readonly MaadContext _context;

    public CustomerFeedbackCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CustomerFeedbackCategory>>> GetAllCustomerFeedbackCategoriesAsync(Ulid businessId)
    {
        try
        {
            var result = await _context.CustomerFeedbackCategories.Where(x => x.IdBusiness == businessId).ToListAsync();
            return new Result<ICollection<CustomerFeedbackCategory>>(result);
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategory>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> GetCustomerFeedbackCategoryByIdAsync(Ulid feedbackCategoryId)
    {
        try
        {
            return await _context.CustomerFeedbackCategories.FirstOrDefaultAsync(x => x.Id == feedbackCategoryId && x.CustomerFeedbackCategoryStatus == Status.Show);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }

    }

    public async ValueTask<Result<ICollection<CustomerFeedbackCategory>>> SearchByItemsAsync(string request)
    {
        try
        {
            return new Result<ICollection<CustomerFeedbackCategory>>
                (await _context.CustomerFeedbackCategories.Where(x => x.Name.Contains(request)).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategory>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> ChangeStatusCustomerFeedbackCategoryByIdAsync(ChangeStatusCustomerFeedbackCategoryCommand request)
    {
        try
        {
            CustomerFeedbackCategory feedbackCategory = new()
            {
                Name = "",
                Id = request.Id,
                CustomerFeedbackCategoryStatus = request.CustomerFeedbackCategoryStatus
            };

            var item = await _context.CustomerFeedbackCategories.FindAsync(request.Id);
            if (item is null) return new Result<CustomerFeedbackCategory>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerFeedbackCategoryStatus = request.CustomerFeedbackCategoryStatus;
            await _context.SaveChangesAsync();
            return new Result<CustomerFeedbackCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> CreateCustomerFeedbackCategoryAsync(CreateCustomerFeedbackCategoryCommand request)
    {
        try
        {
            CustomerFeedbackCategory item = new()
            {
                Name = request.Name,
                TypeFeedback = request.TypeFeedback,
                PositiveNegative = request.PositiveNegative,
                IdBusiness = request.IdBusiness,
                IdUserUpdated = request.IdUserUpdated,
                IdUserAdded = request.IdUserAdded
            };
            await _context.CustomerFeedbackCategories.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<CustomerFeedbackCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> UpdateCustomerFeedbackCategoryAsync(UpdateCustomerFeedbackCategoryCommand request)
    {
        try
        {
            CustomerFeedbackCategory item = await _context.CustomerFeedbackCategories.FindAsync(request.Id);
            item.Id = request.Id;
            item.Name = request.Name;
            item.TypeFeedback = request.TypeFeedback;
            item.PositiveNegative = request.PositiveNegative;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return new Result<CustomerFeedbackCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }

    }

    public async ValueTask<Result<CustomerFeedbackCategory>> DeleteCustomerFeedbackCategoryAsync(Ulid feedbackCategoryId)
    {
        try
        {
            var item = await _context.CustomerFeedbackCategories.FindAsync(feedbackCategoryId);
            item.CustomerFeedbackCategoryStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return new Result<CustomerFeedbackCategory>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new ValidationException(e.Message));
        }

    }
}