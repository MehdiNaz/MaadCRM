namespace DataAccess.Repositories.Customers;

public class CustCategoryRepository : ICustCategoryRepository
{
    private readonly MaadContext _context;

    public CustCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<CustCategory?>> GetAllCustCategoryAsync() => (await _context.CustCategories!.ToListAsync())!;

    public async ValueTask<CustCategory?> GetCustCategoryByIdAsync(Ulid custCategoryId) => await _context.CustCategories!.FindAsync(custCategoryId);

    public async ValueTask<CustCategory?> CreateCustCategoryAsync(CustCategory? entity)
    {
        try
        {
            await _context.CustCategories!.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustCategory?> UpdateCustCategoryAsync(CustCategory entity, Ulid custCategoryId)
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

    public async ValueTask<CustCategory?> DeleteCusCustomerAsync(Ulid custCategoryId)
    {
        try
        {
            var custCategory = await GetCustCategoryByIdAsync(custCategoryId);
            custCategory.IsDeleted = (byte)Status.Deleted;
            await _context.SaveChangesAsync();
            return custCategory;
        }
        catch
        {
            return null;
        }
    }
}