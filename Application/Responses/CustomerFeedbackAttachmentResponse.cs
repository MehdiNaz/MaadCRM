namespace Application.Responses;

public struct CustomerFeedbackAttachmentResponse
{
    public Ulid Id { get; set; }
    public string Name { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
    public Status CustomerFeedbackAttachmentStatus { get; set; }
}
