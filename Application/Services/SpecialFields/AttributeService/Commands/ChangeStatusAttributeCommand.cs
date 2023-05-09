namespace Application.Services.SpecialFields.AttributeService.Commands;

public struct ChangeStatusAttributeCommand : IRequest<Result<AttributeResponse>>
{
    public Ulid Id { get; set; }
    public StatusType Status { get; set; }
}