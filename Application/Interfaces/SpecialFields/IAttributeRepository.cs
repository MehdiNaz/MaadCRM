namespace Application.Interfaces.SpecialFields;

public interface IAttributeRepository
{
    ValueTask<Result<ICollection<AttributeResponse>>> GetAllAttributesAsync(AttributeType type,Ulid idBusiness);
    ValueTask<Result<AttributeResponse>> GetAttributesByIdAsync(Ulid attributeId);
    ValueTask<Result<AttributeResponse>> ChangeStatusAttributeIdAsync(ChangeStatusAttributeCommand request);
    ValueTask<Result<AttributeResponse>> CreateAttributesAsync(CreateAttributeCommand request);
    ValueTask<Result<AttributeResponse>> UpdateAttributesAsync(UpdateAttributeCommand request);
    ValueTask<Result<AttributeResponse>> DeleteAttributesAsync(Ulid attributeId);
}