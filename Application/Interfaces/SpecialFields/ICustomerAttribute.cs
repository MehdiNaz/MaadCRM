namespace Application.Interfaces.SpecialFields;

public interface IAttributeCustomerRepository
{
    ValueTask<Result<ICollection<AttributeCustomerResponse>>> GetAllAttributesAsync(Ulid idCustomer);
    ValueTask<Result<AttributeCustomerResponse>> GetAttributeByIdAsync(Ulid idCustomer);
    ValueTask<Result<AttributeCustomerResponse>> ChangeStatusAttributeIdAsync(ChangeStatusAttributeCustomerCommand request);
    ValueTask<Result<AttributeCustomerResponse>> CreateAttributesAsync(CreateAttributeCustomerCommand request);
    ValueTask<Result<AttributeCustomerResponse>> UpdateAttributesAsync(UpdateAttributeCustomerCommand request);
    ValueTask<Result<AttributeCustomerResponse>> DeleteAttributesAsync(Ulid attributeId);
}