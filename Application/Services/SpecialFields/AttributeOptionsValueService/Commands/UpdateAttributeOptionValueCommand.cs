namespace Application.Services.SpecialFields.AttributeOptionsValueService.Commands;

public struct UpdateAttributeOptionValueCommand : IRequest<Result<AttributeOptionValueResponse>>
{
    public Ulid Id { get; set; }
    public string Value { get; set; }
    public string? FilePath { get; set; }
}