namespace Application.Services.PeyGiryAttachmentService.Commands;

public struct UpdatePeyGiryAttachmentCommand : IRequest<PeyGiryAttachment>
{
    public Ulid PeyGiryAttachmentId { get; set; }
    public Ulid PeyGiryNoteId { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
}