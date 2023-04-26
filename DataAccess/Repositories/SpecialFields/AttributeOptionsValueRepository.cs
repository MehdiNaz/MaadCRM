namespace DataAccess.Repositories.SpecialFields;

public class AttributeOptionsValueRepository : IAttributeOptionsValueRepository
{
    private readonly MaadContext _context;

    public AttributeOptionsValueRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<AttributeOptionsValue?>> GetAllAttributeOptionsValueAsync()
        => await _context.AttributeOptionsValues.Where(x => x.AttributeOptionsValueStatus == Status.Show).ToListAsync();


    public async ValueTask<AttributeOptionsValue?> GetAttributeOptionsValueByIdAsync(int attributeOptionsValueId) 
        => await _context.AttributeOptionsValues.FindAsync(attributeOptionsValueId);

    public async ValueTask<AttributeOptionsValue?> CreateAttributeOptionsValueAsync(AttributeOptionsValue? toCreate)
    {
        await _context.AttributeOptionsValues!.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<AttributeOptionsValue?> UpdateAttributeOptionsValueAsync(string updateContent, int attributeOptionsValueId)
    {
        var attributeOptionsValues = await GetAttributeOptionsValueByIdAsync(attributeOptionsValueId);
        _context.Update(attributeOptionsValues);
        await _context.SaveChangesAsync();
        return attributeOptionsValues;
    }

    public async ValueTask<AttributeOptionsValue?> DeleteAttributeOptionsValueAsync(int attributeOptionsValueId)
    {
        try
        {
            var attributeOptionsValues = await _context.AttributeOptionsValues.FindAsync(attributeOptionsValueId);
            //_context.AttributeOptionsValues!.Remove(attributeOptionsValues);
            attributeOptionsValues.AttributeOptionsValueStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return attributeOptionsValues;
        }
        catch
        {
            return null;
        }
    }
}