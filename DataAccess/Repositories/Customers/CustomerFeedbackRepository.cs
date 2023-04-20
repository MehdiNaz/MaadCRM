using Application.Services.CustomerFeedbackService.Commands;

namespace DataAccess.Repositories.Customers;

public class CustomerFeedbackRepository : ICustomerFeedbackRepository
{
    private readonly MaadContext _context;

    public CustomerFeedbackRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerFeedback?>> GetAllCustomerFeedbacksAsync()
        => await _context.CustomerFeedbacks.Where(x => x.CustomerFeedbackStatus == Status.Show).ToListAsync();


    public async ValueTask<CustomerFeedback?> GetCustomerFeedbackByIdAsync(Ulid customerFeedbackId)
        => await _context.CustomerFeedbacks.FirstOrDefaultAsync(x => x.Id == customerFeedbackId && x.CustomerFeedbackStatus == Status.Show);

    public async ValueTask<CustomerFeedback?> ChangeStatusCustomerFeedbackByIdAsync(ChangeStatusCustomerFeedBackCommand request)
    {
        try
        {
            var item = await _context.CustomerFeedbacks.FindAsync(request.Id);
            if (item is null) return null;
            item.CustomerFeedbackStatus = request.CustomerFeedbackStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerFeedback?> CreateCustomerFeedbackAsync(CreateCustomerFeedBackCommand request)
    {
        try
        {
            CustomerFeedback item = new()
            {
                FeedbackName = request.FeedbackName,
                DisplayOrder = request.DisplayOrder,
                Point = request.Point,
                BalancePoint = request.BalancePoint
            };
            await _context.CustomerFeedbacks!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerFeedback?> UpdateCustomerFeedbackAsync(UpdateCustomerFeedBackCommand request)
    {
        try
        {
            CustomerFeedback item = new()
            {
                Id = request.Id,
                FeedbackName = request.FeedbackName,
                DisplayOrder = request.DisplayOrder,
                Point = request.Point,
                BalancePoint = request.BalancePoint
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

    public async ValueTask<CustomerFeedback?> DeleteCustomerFeedbackAsync(DeleteCustomerFeedBackCommand request)
    {
        try
        {
            var customerFeedback = await GetCustomerFeedbackByIdAsync(request.Id);
            customerFeedback!.CustomerFeedbackStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return customerFeedback;
        }
        catch
        {
            return null;
        }
    }
}