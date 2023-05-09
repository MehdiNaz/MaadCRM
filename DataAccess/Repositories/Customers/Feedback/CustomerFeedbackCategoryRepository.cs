namespace DataAccess.Repositories.Customers.Feedback;

public class CustomerFeedbackCategoryRepository : ICustomerFeedbackCategoryRepository
{
    private readonly MaadContext _context;

    public CustomerFeedbackCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CustomerFeedbackCategoryResponse>>> GetAllCustomerFeedbackCategoriesAsync(Ulid businessId)
    {
        try
        {
            return await _context.CustomerFeedbackCategories.Where(x => x.IdBusiness == businessId && x.CustomerFeedbackCategoryStatusType == StatusType.Show)
                .Select(x => new CustomerFeedbackCategoryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    PositiveNegative = x.PositiveNegative,
                    CustomerFeedbackCategoryStatusType = x.CustomerFeedbackCategoryStatusType,
                    TypeFeedback = x.TypeFeedback
                })
                .ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategoryResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategoryResponse>> GetCustomerFeedbackCategoryByIdAsync(Ulid feedbackCategoryId)
    {
        try
        {
            return await _context.CustomerFeedbackCategories.FirstOrDefaultAsync(x => x.Id == feedbackCategoryId && x.CustomerFeedbackCategoryStatusType == StatusType.Show)
                .Select(x => new CustomerFeedbackCategoryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    PositiveNegative = x.PositiveNegative,
                    CustomerFeedbackCategoryStatusType = x.CustomerFeedbackCategoryStatusType,
                    TypeFeedback = x.TypeFeedback
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<CustomerFeedbackCategoryResponse>>> SearchByItemsAsync(Ulid businessId, string request)
    {
        try
        {
            return await _context.CustomerFeedbackCategories
                .Where(x => x.IdBusiness == businessId && x.CustomerFeedbackCategoryStatusType == StatusType.Show && x.Name.ToLower()
                .Contains(request.ToLower()))
                .Select(x => new CustomerFeedbackCategoryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    PositiveNegative = x.PositiveNegative,
                    CustomerFeedbackCategoryStatusType = x.CustomerFeedbackCategoryStatusType,
                    TypeFeedback = x.TypeFeedback
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategoryResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategoryResponse>> ChangeStatusCustomerFeedbackCategoryByIdAsync(ChangeStatusCustomerFeedbackCategoryCommand request)
    {
        try
        {
            CustomerFeedbackCategory feedbackCategory = new()
            {
                Name = "",
                Id = request.Id,
                CustomerFeedbackCategoryStatusType = request.CustomerFeedbackCategoryStatusType
            };

            var item = await _context.CustomerFeedbackCategories.FindAsync(request.Id);
            if (item is null) return new Result<CustomerFeedbackCategoryResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerFeedbackCategoryStatusType = request.CustomerFeedbackCategoryStatusType;
            await _context.SaveChangesAsync();
            return await _context.CustomerFeedbackCategories.FindAsync(request.Id)
                .Select(x => new CustomerFeedbackCategoryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    PositiveNegative = x.PositiveNegative,
                    CustomerFeedbackCategoryStatusType = x.CustomerFeedbackCategoryStatusType,
                    TypeFeedback = x.TypeFeedback
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategoryResponse>> CreateCustomerFeedbackCategoryAsync(CreateCustomerFeedbackCategoryCommand request)
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
            return await _context.CustomerFeedbackCategories.FirstOrDefaultAsync(x => x.Name == request.Name && x.IdUserAdded == request.IdUserAdded)
                .Select(x => new CustomerFeedbackCategoryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    PositiveNegative = x.PositiveNegative,
                    CustomerFeedbackCategoryStatusType = x.CustomerFeedbackCategoryStatusType,
                    TypeFeedback = x.TypeFeedback
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackCategoryResponse>> UpdateCustomerFeedbackCategoryAsync(UpdateCustomerFeedbackCategoryCommand request)
    {
        try
        {
            CustomerFeedbackCategory item = await _context.CustomerFeedbackCategories.FindAsync(request.Id);
            item.Name = request.Name;
            item.TypeFeedback = request.TypeFeedback;
            item.PositiveNegative = request.PositiveNegative;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return await _context.CustomerFeedbackCategories.FindAsync(request.Id)
                .Select(x => new CustomerFeedbackCategoryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    PositiveNegative = x.PositiveNegative,
                    CustomerFeedbackCategoryStatusType = x.CustomerFeedbackCategoryStatusType,
                    TypeFeedback = x.TypeFeedback
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new ValidationException(e.Message));
        }

    }

    public async ValueTask<Result<CustomerFeedbackCategoryResponse>> DeleteCustomerFeedbackCategoryAsync(Ulid feedbackCategoryId)
    {
        try
        {
            var item = await _context.CustomerFeedbackCategories.FindAsync(feedbackCategoryId);
            item.CustomerFeedbackCategoryStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return await _context.CustomerFeedbackCategories.FindAsync(feedbackCategoryId)
                .Select(x => new CustomerFeedbackCategoryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    PositiveNegative = x.PositiveNegative,
                    CustomerFeedbackCategoryStatusType = x.CustomerFeedbackCategoryStatusType,
                    TypeFeedback = x.TypeFeedback
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new ValidationException(e.Message));
        }

    }
}