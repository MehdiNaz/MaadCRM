namespace Application.Interfaces.SpecialFields;

public interface IAttributeOptionsRepository
{
    ValueTask<ICollection<AttributeOption?>> GetAllAttributeOptionsAsync();
    ValueTask<AttributeOption?> GetAttributeOptionsByIdAsync(int attributeOptionsId);
    ValueTask<AttributeOption?> CreateAttributeOptionsAsync(AttributeOption? toCreate);
    ValueTask<AttributeOption?> UpdateAttributeOptionsAsync(string updateContent, int attributeOptionsId);
    ValueTask<AttributeOption?> DeleteAttributeOptionsAsync(int attributeOptionsId);
}