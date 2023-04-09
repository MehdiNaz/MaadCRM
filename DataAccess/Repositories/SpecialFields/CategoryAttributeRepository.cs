namespace DataAccess.Repositories.SpecialFields;

public class CategoryAttributeRepository : ICategoryAttributeRepository
{
    private readonly MaadContext _context;

    public CategoryAttributeRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CategoryAttribute?>> GetAllCategoryAttributeAsync() => (await _context.CategoryAttributes!.ToListAsync())!;

    public async ValueTask<CategoryAttribute?> GetCategoryAttributeByIdAsync(int categoryAttributeId) => await _context.CategoryAttributes!.FindAsync(categoryAttributeId);

    public async ValueTask<CategoryAttribute?> CreateCategoryAttributeAsync(CategoryAttribute? toCreate)
    {
        await _context.CategoryAttributes!.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<CategoryAttribute?> UpdateCategoryAttributeAsync(string updateContent, int categoryAttributeId)
    {
        var categoryAttribute = await GetCategoryAttributeByIdAsync(categoryAttributeId);
        _context.Update(categoryAttribute);
        await _context.SaveChangesAsync();
        return categoryAttribute;
    }

    public async ValueTask<CategoryAttribute?> DeleteCategoryAttributeAsync(int categoryAttributeId)
    {
        try
        {
            var categoryAttribute = await GetCategoryAttributeByIdAsync(categoryAttributeId);
            //_context.CategoryAttributes!.Remove(categoryAttribute);
            categoryAttribute.CategoryAttributeStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return categoryAttribute;
        }
        catch
        {
            return null;
        }
    }
}