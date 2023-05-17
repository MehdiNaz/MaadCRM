using Application.Services.SpecialFields.CustomerAttributeService.Commands;

namespace Application.Interfaces.SpecialFields;

public interface ICustomerAttribute
{
    ValueTask<Result<ICollection<CustomerAttributeResponse>>> GetAllForooshOrdersAsync();
    ValueTask<Result<CustomerAttributeResponse>> GetForooshOrderByIdAsync(Ulid customerAttributeId);
    ValueTask<Result<CustomerAttributeResponse>> ChangeStatusForooshOrderByIdAsync(ChangeStatusForooshOrderCommand request);
    ValueTask<Result<CustomerAttributeResponse>> CreateForooshOrderAsync(CreateCustomerAttributeCommand request);
    ValueTask<Result<CustomerAttributeResponse>> UpdateForooshOrderAsync(UpdateCustomerAttributeCommand request);
    ValueTask<Result<CustomerAttributeResponse>> DeleteForooshOrderAsync(Ulid customerAttributeId);
}