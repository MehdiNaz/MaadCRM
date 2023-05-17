namespace Application.Services.SpecialFields.CustomerAttributeService.Commands;

public struct ChangeStatusCustomerAttributeCommand : IRequest<Result<CustomerAttributeResponse>>
{
    public Ulid Id { get; set; }
    public StatusType Status { get; set; }
}