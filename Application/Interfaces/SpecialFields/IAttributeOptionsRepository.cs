namespace Application.Interfaces.SpecialFields;

public interface IAttributeOptionsRepository
{
    ValueTask<Result<ICollection<AttributeOptionResponse>>> GetAllAttributeOptionsAsync();
    ValueTask<Result<AttributeOptionResponse>> GetAttributeOptionsByIdAsync(Ulid attributeOptionsId);
    ValueTask<Result<AttributeOptionResponse>> ChangeStatusAttributeIdAsync(ChangeStatusAttributeOptionCommand request);
    ValueTask<Result<AttributeOptionResponse>> CreateAttributeOptionsAsync(CreateAttributeOptionCommand request);
    ValueTask<Result<AttributeOptionResponse>> UpdateAttributeOptionsAsync(UpdateAttributeOptionCommand request);
    ValueTask<Result<AttributeOptionResponse>> DeleteAttributeOptionsAsync(Ulid attributeOptionsId);
}