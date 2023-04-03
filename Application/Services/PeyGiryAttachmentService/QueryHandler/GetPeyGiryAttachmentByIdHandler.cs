namespace Application.Services.PeyGiryAttachmentService.QueryHandler;

public class GetPeyGiryAttachmentByIdHandler : IRequestHandler<GetPeyGiryAttachmentByIdQuery, PeyGiryAttachment>
{
    private readonly IPeyGiryAttachmentRepository _repository;

    public GetPeyGiryAttachmentByIdHandler(IPeyGiryAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PeyGiryAttachment> Handle(GetPeyGiryAttachmentByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetPeyGiryAttachmentByIdAsync(request.PeyGiryAttachmentId))!;
}