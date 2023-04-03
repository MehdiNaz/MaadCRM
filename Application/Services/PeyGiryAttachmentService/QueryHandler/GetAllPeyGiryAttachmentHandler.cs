namespace Application.Services.PeyGiryAttachmentService.QueryHandler;

public class GetAllPeyGiryAttachmentHandler : IRequestHandler<GetAllPeyGiryAttachmentQuery, ICollection<PeyGiryAttachment>>
{
    private readonly IPeyGiryAttachmentRepository _repository;

    public GetAllPeyGiryAttachmentHandler(IPeyGiryAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<PeyGiryAttachment>> Handle(GetAllPeyGiryAttachmentQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllPeyGiryAttachmentsAsync())!;
}
