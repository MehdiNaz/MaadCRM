namespace Application.Services.PeyGiryAttachmentService.QueryHandler;

public readonly struct PeyGiryAttachmentByIdHandler : IRequestHandler<PeyGiryAttachmentByIdQuery, PeyGiryAttachment>
{
    private readonly IPeyGiryAttachmentRepository _repository;

    public PeyGiryAttachmentByIdHandler(IPeyGiryAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PeyGiryAttachment> Handle(PeyGiryAttachmentByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetPeyGiryAttachmentByIdAsync(request.PeyGiryAttachmentId))!;
}