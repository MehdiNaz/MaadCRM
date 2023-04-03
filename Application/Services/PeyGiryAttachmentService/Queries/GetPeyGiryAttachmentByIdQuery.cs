namespace Application.Services.PeyGiryAttachmentService.Queries;

public struct GetPeyGiryAttachmentByIdQuery : IRequest<PeyGiryAttachment>
{
    public Ulid PeyGiryAttachmentId { get; set; }
}