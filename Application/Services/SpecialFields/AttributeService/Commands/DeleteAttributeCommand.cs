namespace Application.Services.SpecialFields.AttributeService.Commands;

public struct DeleteAttributeCommand : IRequest<Result<AttributeResponse>>
{
    public Ulid Id { get; set; }
}