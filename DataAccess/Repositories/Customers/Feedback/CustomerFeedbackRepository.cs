namespace DataAccess.Repositories.Customers.Feedback;

public class CustomerFeedbackRepository : ICustomerFeedbackRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    public CustomerFeedbackRepository(MaadContext context, ILogRepository log)
    {
        _context = context;
        _log = log;
    }

    private async ValueTask<Result<CustomerFeedbackResponse>> CalculateAsync(
        Ulid? idCustomer, Ulid idCustomerFeedback)
    {
        try
        {
            if (idCustomer is not null)
            {
                var customer = await _context.Customers
                    .Include(i => i.Moarefs)
                    .Include(i => i.ForooshFactors)
                    .Include(i => i.CustomerFeedbacks!)
                    .ThenInclude(i => i.IdCategoryNavigation)
                    .FirstOrDefaultAsync(x => x.Id == idCustomer);
                if (customer is null) return new Result<CustomerFeedbackResponse>(new ValidationException(ResultErrorMessage.NotFound));

                var positive = customer.CustomerFeedbacks?.Count(w => w.IdCategoryNavigation?.PositiveNegative == true) ?? 0;
                var negative =
                    customer.CustomerFeedbacks?.Count(w => w.IdCategoryNavigation?.PositiveNegative == false) ?? 0;
                var sum = positive + negative;
                var percent = positive / sum * 100;

                var moaref = customer.Moarefs!.Any();
                var kharid = customer.ForooshFactors!.Any();
                
                // TODO: Customer State FeedBack
                if (moaref && kharid)
                {
                    customer.CustomerState = CustomerStateTypes.Vafadar;
                }
                else if (positive > 5)
                {
                    customer.CustomerState = CustomerStateTypes.Razy;
                }
                else if (positive > 2 || percent > 75)
                {
                    customer.CustomerState = CustomerStateTypes.Razy;
                }
                else if (negative > 2)
                {
                    customer.CustomerState = CustomerStateTypes.NaRazy;
                }

                await _context.SaveChangesAsync();
            }
            
            
            return new Result<CustomerFeedbackResponse>(await _context.CustomerFeedbacks
                .Include(u => u.IdUserNavigation)
                .Include(p => p.IdProductNavigation)
                .Select(x => new CustomerFeedbackResponse
                {
                    Id = x!.Id,
                    CustomerFeedbackStatusType = x.CustomerFeedbackStatusType,
                    Description = x.Description,
                    IdCustomer = x.IdCustomer,
                    IdCategory = x.IdCategory,
                    IdProduct = x.IdProduct,
                    IdUserAdded = x.IdUser,
                    IdUserUpdated = x.IdUser,
                    IdUser = x.IdUser,
                    UserFullName = x.IdUserNavigation!.Name + " " + x.IdUserNavigation.Family
                })
                .FirstOrDefaultAsync(w => w.Id == idCustomerFeedback && w.CustomerFeedbackStatusType == StatusType.Show));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new ValidationException(e.Message));
        }
    }
    public async ValueTask<Result<ICollection<CustomerFeedbackResponse>>> GetAllCustomerFeedbacksAsync(Ulid idCustomer)
    {
        try
        {
            return new Result<ICollection<CustomerFeedbackResponse>>(await _context.CustomerFeedbacks
                .Where(x => x.CustomerFeedbackStatusType == StatusType.Show && x.IdCustomer == idCustomer)
                .Include(x => x.IdUserNavigation)
                .Select(x => new CustomerFeedbackResponse
                {
                    Id = x.Id,
                    CustomerFeedbackStatusType = x.CustomerFeedbackStatusType,
                    Description = x.Description,
                    IdCustomer = x.IdCustomer,
                    IdCategory = x.IdCategory,
                    IdProduct = x.IdProduct,
                    IdUserAdded = x.IdUser,
                    IdUserUpdated = x.IdUser,
                    IdUser = x.IdUser,
                    UserFullName = x.IdUserNavigation.Name + " " + x.IdUserNavigation.Family
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackResponse>> GetCustomerFeedbackByIdAsync(Ulid feedbackId)
    {
        try
        {
            return await CalculateAsync(null, feedbackId);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<CustomerFeedbackResponse>>> SearchByItemsAsync(string request, string userId)
    {
        try
        {
            return new Result<ICollection<CustomerFeedbackResponse>>
            (await _context.CustomerFeedbacks
                .Include(x => x.IdUserNavigation)
                .Where(x => x.IdUserAdded == userId)
                .Where(x => x.Description.ToLower().Contains(request.ToLower()))
                .Select(x => new CustomerFeedbackResponse
                {
                    Id = x.Id,
                    CustomerFeedbackStatusType = x.CustomerFeedbackStatusType,
                    Description = x.Description,
                    IdCustomer = x.IdCustomer,
                    IdCategory = x.IdCategory,
                    IdProduct = x.IdProduct,
                    IdUserAdded = x.IdUserNavigation.Id,
                    IdUser = x.IdUser,
                    UserFullName = x.IdUserNavigation.Name + " " + x.IdUserNavigation.Family
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackResponse>> ChangeStatusCustomerFeedbacksByIdAsync(ChangeStateCustomerFeedbackCommand request)
    {
        try
        {
            var item = await _context.CustomerFeedbacks.FindAsync(request.Id);
            if (item is null) return new Result<CustomerFeedbackResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerFeedbackStatusType = request.CustomerFeedbackStatusType;
            await _context.SaveChangesAsync();

            return await CalculateAsync(item.IdCustomer, request.Id);
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackResponse>> CreateCustomerFeedbackAsync(CreateCustomerFeedbackCommand request)
    {
        try
        {
            CustomerFeedback item = new()
            {
                Description = request.Description,
                IdCategory = request.IdCategory,
                IdProduct = request.IdProduct,
                IdCustomer = request.IdCustomer,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated,
                IdUser = request.IdUser
            };
            await _context.CustomerFeedbacks.AddAsync(item);
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = item.Id,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.InsertFeedBack,
                UserId = "request.IdUserAdded",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            return await CalculateAsync(item.IdCustomer, item.Id);

            
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackResponse>> UpdateCustomerFeedbackAsync(UpdateCustomerFeedbackCommand request)
    {
        try
        {
            CustomerFeedback item = await _context.CustomerFeedbacks.FindAsync(request.Id);
            item.Description = request.Description;
            item.IdUser = request.IdUser;

            _context.Update(item);
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = request.Id,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.UpdateFeedBack,
                UserId = "request.IdUserAdded",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);
            
            return await CalculateAsync(item.IdCustomer, request.Id);

        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<string> DeleteCustomerFeedbackAsync(Ulid id)
    {
        try
        {
            var item = await _context.CustomerFeedbacks.FindAsync(id);
            item.CustomerFeedbackStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = id,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.DeleteFeedBack,
                UserId = "request.IdUser",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);
            
            await CalculateAsync(item.IdCustomer, item.Id);

            return "Customer Feedback Deleted.";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}
