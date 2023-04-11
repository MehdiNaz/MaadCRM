namespace DataAccess.Repositories.Customers;

public class CustomerCategoryRepository : ICustomerCategoryRepository
{
    private readonly MaadContext _context;

    public CustomerCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerCategory?>> GetAllCustomerCategoryAsync()
        => await _context.CustomerCategories.Where(x => x.CustomerCategoryStatus == Status.Show).ToListAsync();

    public async ValueTask<CustomerCategory?> GetCustomerCategoryByIdAsync(Ulid customerCategoryId) 
        => await _context.CustomerCategories!.FindAsync(customerCategoryId);

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

    public async ValueTask<CustomerCategory?> DeleteCusCustomerAsync(Ulid customerCategoryId)
    {
        try
        {
            var CustomerCategory = await GetCustomerCategoryByIdAsync(customerCategoryId);
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