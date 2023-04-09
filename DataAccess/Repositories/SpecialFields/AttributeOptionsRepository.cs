namespace DataAccess.Repositories.SpecialFields;

public class AttributeOptionsRepository : IAttributeOptionsRepository
{
    private readonly MaadContext _context;

    public AttributeOptionsRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<AttributeOptions?>> GetAllAttributeOptionsAsync() => (await _context.AttributeOptions!.ToListAsync())!;

    public async ValueTask<AttributeOptions?> GetAttributeOptionsByIdAsync(int attributeOptionsId) => await _context.AttributeOptions!.FindAsync(attributeOptionsId);

    public async ValueTask<AttributeOptions?> CreateAttributeOptionsAsync(AttributeOptions? toCreate)
    {
        await _context.AttributeOptions!.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<AttributeOptions?> UpdateAttributeOptionsAsync(string updateContent, int attributeOptionsId)
    {
        var attributeOptions = await GetAttributeOptionsByIdAsync(attributeOptionsId);
        _context.Update(attributeOptions);
        await _context.SaveChangesAsync();
        return attributeOptions;
    }

    public async ValueTask<AttributeOptions?> DeleteAttributeOptionsAsync(int attributeOptionsId)
    {
        try
        {
            var attributeOptions = await GetAttributeOptionsByIdAsync(attributeOptionsId);
            //_context.AttributeOptions!.Remove(attributeOptions);
            attributeOptions.AttributeOptionsStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return attributeOptions;
        }
        catch
        {
            return null;
        }
    }
}