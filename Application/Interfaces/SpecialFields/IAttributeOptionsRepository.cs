namespace Application.Interfaces.SpecialFields;

public interface IAttributeOptionsRepository
{
    ValueTask<ICollection<AttributeOptions?>> GetAllAttributeOptionsAsync();
    ValueTask<AttributeOptions?> GetAttributeOptionsByIdAsync(int attributeOptionsId);
    ValueTask<AttributeOptions?> CreateAttributeOptionsAsync(AttributeOptions? toCreate);
    ValueTask<AttributeOptions?> UpdateAttributeOptionsAsync(string updateContent, int attributeOptionsId);
    ValueTask DeleteAttributeOptionsAsync(int attributeOptionsId);
}