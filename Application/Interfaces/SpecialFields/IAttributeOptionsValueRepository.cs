namespace Application.Interfaces.SpecialFields;

public interface IAttributeOptionsValueRepository
{
    ValueTask<Result<ICollection<AttributeOptionValueResponse>>> GetAllAttributeOptionsValueAsync();
    ValueTask<Result<AttributeOptionValueResponse>> GetAttributeOptionsValueByIdAsync(Ulid attributeOptionsValueId);
    ValueTask<Result<AttributeOptionValueResponse>> ChangeStatusAttributeOptionsByIdAsync(ChangeStatusAttributeOptionValueCommand request);
    ValueTask<Result<AttributeOptionValueResponse>> CreateAttributeOptionsValueAsync(CreateAttributeOptionValueCommand request);
    ValueTask<Result<AttributeOptionValueResponse>> UpdateAttributeOptionsValueAsync(UpdateAttributeOptionValueCommand request);
    ValueTask<Result<AttributeOptionValueResponse>> DeleteAttributeOptionsValueAsync(Ulid attributeOptionsValueId);
}