namespace Application.Services.SpecialFields.AttributeOptionService.Commands;

public struct CreateAttributeOptionCommand : IRequest<Result<AttributeOptionResponse>>
{
    public string Title { get; set; }
    public string? ColorSquaresRgb { get; set; }
    public int DisplayOrder { get; set; }
    public Ulid? IdAttribute { get; set; }
}