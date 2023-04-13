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
            x.CustomerCategoryId == customerCategoryId
            && x.CustomerCategoryStatus == Status.Show
            && x.UserId == userId);

    public async ValueTask<CustomerCategory?> ChangeStatusCustomerCategoryByIdAsync(Status status, Ulid customerCategoryId)
    {
        try
        {
            var item = await _context.CustomerCategories.FindAsync(customerCategoryId);
            if (item is null) return null;
            item.CustomerCategoryStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerCategory?> CreateCustomerCategoryAsync(CustomerCategory? entity)
    {
        try
        {
            await _context.CustomerCategories!.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerCategory?> UpdateCustomerCategoryAsync(CustomerCategory entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerCategory?> DeleteCusCustomerAsync(Ulid customerCategoryId, string userId)
    {
        try
        {
            var CustomerCategory = await GetCustomerCategoryByIdAsync(customerCategoryId,userId);
            CustomerCategory.CustomerCategoryStatus = Status.Show;
            await _context.SaveChangesAsync();
            return CustomerCategory;
        }
        catch
        {
            return null;
        }
    }
}