namespace Application.Services.SpecialFields.AttributeOptionsValueService.Commands;

public struct CreateAttributeOptionValueCommand : IRequest<Result<AttributeOptionValueResponse>>
{
    public string Value { get; set; }
    public string? FilePath { get; set; }
    public Ulid? IdAttributeOption { get; set; }
}