namespace Application.Responses;

public struct PeyGiryCategoryResponse
{
    public Ulid Id { get; set; }
    public string Kind { get; set; }
    public Ulid? IdBusiness { get; set; }
    public StatusType Status { get; set; }
}