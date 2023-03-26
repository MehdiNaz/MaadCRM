namespace DataAccess.Repositories.Customers;

public class CustCategoryRepository : ICustCategoryRepository
{
    private readonly MaadContext _context;

    public CustCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<CustCategory?>> GetAllCustCategoryAsync() => (await _context.CustCategories!.ToListAsync())!;

    public async ValueTask<CustCategory?> GetCustCategoryByIdAsync(int custCategoryId) => await _context.CustCategories!.FindAsync(custCategoryId);

    public async ValueTask<CustCategory?> CreateCustCategoryAsync(CustCategory? toCreate)
    {
        await _context.CustCategories!.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<CustCategory?> UpdateCustCategoryAsync(string updateContent, int custCategoryId)
    {
        var custCategory = await GetCustCategoryByIdAsync(custCategoryId);
        _context.Update(custCategory);
        await _context.SaveChangesAsync();
        return custCategory;
    }

    public async ValueTask DeleteCusCustomerAsync(int custCategoryId)
    {
        var custCategory = await GetCustCategoryByIdAsync(custCategoryId);
        _context.CustCategories.Remove(custCategory);
        await _context.SaveChangesAsync();
    }
}