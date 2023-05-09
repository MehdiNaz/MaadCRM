namespace Application.Services.SpecialFields.AttributeOptionService.Commands;

public struct ChangeStatusAttributeOptionCommand : IRequest<Result<AttributeOptionResponse>>
{
    public Ulid Id { get; set; }
    public StatusType Status { get; set; }
}