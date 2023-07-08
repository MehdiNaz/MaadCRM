namespace Application.Responses.SpecialFields;

public struct AttributeOptionValueResponse
{
    public Ulid Id { get; set; }
    public string Value { get; set; }
    public string? FilePath { get; set; }
    public StatusType Status { get; set; }
    public Ulid? IdAttributeOption { get; set; }
}