namespace Application.Services.PeyGiryAttachmentService.QueryHandler;

public class AllPeyGiryAttachmentHandler : IRequestHandler<AllPeyGiryAttachmentQuery, ICollection<PeyGiryAttachment>>
{
    private readonly IPeyGiryAttachmentRepository _repository;

    public AllPeyGiryAttachmentHandler(IPeyGiryAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<PeyGiryAttachment>> Handle(AllPeyGiryAttachmentQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllPeyGiryAttachmentsAsync())!;
}
