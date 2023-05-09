namespace Application.Services.SpecialFields.AttributeOptionService.Commands;

public struct DeleteAttributeOptionCommand : IRequest<Result<AttributeOptionResponse>>
{
    public Ulid Id { get; set; }
}