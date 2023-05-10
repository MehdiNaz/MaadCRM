namespace Application.Services.SpecialFields.AttributeOptionsValueService.Commands;

public struct ChangeStatusAttributeOptionValueCommand : IRequest<Result<AttributeOptionValueResponse>>
{
    public Ulid Id { get; set; }
    public StatusType Status { get; set; }
}