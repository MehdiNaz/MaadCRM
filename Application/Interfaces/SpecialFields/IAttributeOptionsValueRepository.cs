namespace Application.Interfaces.SpecialFields;

public interface IAttributeOptionsValueRepository
{
    ValueTask<ICollection<AttributeOptionsValue?>> GetAllAttributeOptionsValueAsync();
    ValueTask<AttributeOptionsValue?> GetAttributeOptionsValueByIdAsync(int attributeOptionsValueId);
    ValueTask<AttributeOptionsValue?> CreateAttributeOptionsValueAsync(AttributeOptionsValue? toCreate);
    ValueTask<AttributeOptionsValue?> UpdateAttributeOptionsValueAsync(string updateContent, int attributeOptionsValueId);
    ValueTask<AttributeOptionsValue?> DeleteAttributeOptionsValueAsync(int attributeOptionsValueId);
}