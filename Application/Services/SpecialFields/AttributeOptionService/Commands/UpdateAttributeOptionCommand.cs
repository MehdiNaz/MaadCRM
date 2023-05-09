namespace Application.Services.SpecialFields.AttributeOptionService.Commands;

public struct UpdateAttributeOptionCommand : IRequest<Result<AttributeOptionResponse>>
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public string? ColorSquaresRgb { get; set; }
    public int DisplayOrder { get; set; }
}