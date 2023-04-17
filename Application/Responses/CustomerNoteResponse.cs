namespace Application.Responses;

public struct CustomerNoteResponse
{
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomerNoteStatus { get; set; }
    public Ulid ProductId { get; set; }
}