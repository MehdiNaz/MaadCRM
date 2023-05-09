namespace Application.Responses;

public struct AttributeOptionResponse
{
    public Ulid Id { get; set; }
    public required string Title { get; set; }
    public string? ColorSquaresRgb { get; set; }
    public int DisplayOrder { get; set; }
    public StatusType Status { get; set; }
    public Ulid? IdAttribute { get; set; }
}