namespace DataAccess.Repositories.Customers;

public class CustomerCategoryRepository : ICustomerCategoryRepository
{
    private readonly MaadContext _context;

    public CustomerCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<CustomerCategory?>> GetAllCustomerCategoryAsync()
        => (await _context.CustomerCategories!.ToListAsync()).Where(x => x.IsDeleted == Status.NotDeleted).ToList()!;

    public async ValueTask<CustomerCategory?> GetCustomerCategoryByIdAsync(Ulid customerCategoryId) => await _context.CustomerCategories!.FindAsync(customerCategoryId);

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

    public async ValueTask<CustomerCategory?> UpdateCustomerCategoryAsync(CustomerCategory entity, Ulid customerCategoryId)
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
            CustomerCategory.IsDeleted = Status.Deleted;
            await _context.SaveChangesAsync();
            return CustomerCategory;
        }
        catch
        {
            return null;
        }
    }
}