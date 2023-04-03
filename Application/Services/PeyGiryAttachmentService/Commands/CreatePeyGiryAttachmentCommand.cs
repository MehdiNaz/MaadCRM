namespace Application.Services.PeyGiryAttachmentService.Commands;

public struct CreatePeyGiryAttachmentCommand : IRequest<PeyGiryAttachment>
{
    public Ulid PeyGiryNoteId { get; set; }
    public byte[] FileName { get; set; }
    public string Extenstion { get; set; }
}