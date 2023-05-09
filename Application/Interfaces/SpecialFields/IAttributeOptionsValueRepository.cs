namespace Application.Interfaces.SpecialFields;

public interface IAttributeOptionsValueRepository
{
    ValueTask<ICollection<AttributeOptionValue?>> GetAllAttributeOptionsValueAsync();
    ValueTask<AttributeOptionValue?> GetAttributeOptionsValueByIdAsync(int attributeOptionsValueId);
    ValueTask<AttributeOptionValue?> CreateAttributeOptionsValueAsync(AttributeOptionValue? toCreate);
    ValueTask<AttributeOptionValue?> UpdateAttributeOptionsValueAsync(string updateContent, int attributeOptionsValueId);
    ValueTask<AttributeOptionValue?> DeleteAttributeOptionsValueAsync(int attributeOptionsValueId);
}