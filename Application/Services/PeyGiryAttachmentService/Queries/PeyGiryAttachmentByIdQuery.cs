namespace Application.Services.PeyGiryAttachmentService.Queries;

public struct PeyGiryAttachmentByIdQuery : IRequest<PeyGiryAttachment>
{
    public Ulid PeyGiryAttachmentId { get; set; }
}