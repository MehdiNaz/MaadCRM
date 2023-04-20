namespace Application.Services.PeyGiryAttachmentService.Commands;

public struct DeletePeyGiryAttachmentCommand : IRequest<PeyGiryAttachment>
{
    public Ulid Id { get; set; }
}