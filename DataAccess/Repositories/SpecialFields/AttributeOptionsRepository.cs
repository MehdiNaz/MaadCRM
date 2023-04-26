namespace DataAccess.Repositories.SpecialFields;

public class AttributeOptionsRepository : IAttributeOptionsRepository
{
    private readonly MaadContext _context;

    public AttributeOptionsRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<AttributeOption?>> GetAllAttributeOptionsAsync()
        => await _context.AttributeOptions.Where(x => x.AttributeOptionsStatus == Status.Show).ToListAsync();

    public async ValueTask<AttributeOption?> GetAttributeOptionsByIdAsync(int attributeOptionsId)
        => await _context.AttributeOptions.FindAsync(attributeOptionsId);

    public async ValueTask<AttributeOption?> CreateAttributeOptionsAsync(AttributeOption? toCreate)
    {
        await _context.AttributeOptions!.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<AttributeOption?> UpdateAttributeOptionsAsync(string updateContent, int attributeOptionsId)
    {
        var attributeOptions = await GetAttributeOptionsByIdAsync(attributeOptionsId);
        _context.Update(attributeOptions);
        await _context.SaveChangesAsync();
        return attributeOptions;
    }

    public async ValueTask<AttributeOption?> DeleteAttributeOptionsAsync(int attributeOptionsId)
    {
        try
        {
            var attributeOptions = await _context.AttributeOptions.FindAsync(attributeOptionsId);
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