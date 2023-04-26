namespace DataAccess.Repositories.Customers;

public class CustomerCategoryRepository : ICustomerCategoryRepository
{
    private readonly MaadContext _context;

    public CustomerCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerCategory?>> GetAllCustomerCategoryAsync(string userId)
        => await _context.CustomerCategories.Where(x => x.CustomerCategoryStatus == Status.Show && x.UserId == userId).ToListAsync();

    public async ValueTask<CustomerCategory?> GetCustomerCategoryByIdAsync(Ulid customerCategoryId, string userId)
        => await _context.CustomerCategories.FirstOrDefaultAsync(x =>
            x.Id == customerCategoryId
            && x.CustomerCategoryStatus == Status.Show
            && x.UserId == userId);

    public async ValueTask<CustomerCategory?> ChangeStatusCustomerCategoryByIdAsync(ChangeStatusCustomerCategoryCommand request)
    {
        try
        {
            var item = await _context.CustomerCategories.FindAsync(request.Id);
            if (item is null) return null;
            item.CustomerCategoryStatus = request.CustomerCategoryStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerCategory?> CreateCustomerCategoryAsync(CreateCustomerCategoryCommand request)
    {
        try
        {
            CustomerCategory item = new()
            {
                UserId = request.UserId,
                CustomerCategoryName = request.CustomerCategoryName
            };
            await _context.CustomerCategories!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerCategory?> UpdateCustomerCategoryAsync(UpdateCustomerCategoryCommand request)
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
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerCategory?> DeleteCustomerCategoryAsync(Ulid id)
    {
        try
        {
            var CustomerCategory = await _context.CustomerCategories.FindAsync(id);
            CustomerCategory.CustomerCategoryStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return CustomerCategory;
        }
        catch
        {
            return null;
        }
    }
}