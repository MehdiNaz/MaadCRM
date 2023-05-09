namespace Application.Services.PeyGiryAttachmentService.Commands;

public struct ChangeStatusPeyGiryAttachmentCommand : IRequest<PeyGiryAttachment?>
{
    public Ulid Id { get; set; }
    public StatusType StatusTypePeyGiryAttachment { get; set; }
}