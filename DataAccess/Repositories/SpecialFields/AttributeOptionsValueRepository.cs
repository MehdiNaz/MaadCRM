﻿namespace DataAccess.Repositories.SpecialFields;

public class AttributeOptionsValueRepository : IAttributeOptionsValueRepository
{
    private readonly MaadContext _context;

    public AttributeOptionsValueRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<AttributeOptionsValue?>> GetAllAttributeOptionsValueAsync() => (await _context.AttributeOptionsValues!.ToListAsync())!;


    public async ValueTask<AttributeOptionsValue?> GetAttributeOptionsValueByIdAsync(int attributeOptionsValueId) => await _context.AttributeOptionsValues!.FindAsync(attributeOptionsValueId);

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

    public async ValueTask DeleteAttributeOptionsValueAsync(int attributeOptionsValueId)
    {
        var attributeOptionsValues = await GetAttributeOptionsValueByIdAsync(attributeOptionsValueId);
        _context.AttributeOptionsValues!.Remove(attributeOptionsValues);
        await _context.SaveChangesAsync();
    }
}