namespace Application.Services.PeyGiryAttachmentService.Commands;

public struct ChangeStatusPeyGiryAttachmentCommand : IRequest<PeyGiryAttachment?>
{
    public Ulid PeyGiryAttachmentId { get; set; }
    public Status StatusPeyGiryAttachment { get; set; }
}