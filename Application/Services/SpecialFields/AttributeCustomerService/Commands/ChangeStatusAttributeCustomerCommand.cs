namespace Application.Services.SpecialFields.AttributeCustomerService.Commands;

public struct ChangeStatusAttributeCustomerCommand : IRequest<Result<AttributeCustomerResponse>>
{
    public Ulid Id { get; set; }
    public StatusType Status { get; set; }
}