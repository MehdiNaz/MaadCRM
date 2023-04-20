namespace Application.Services.PeyGiryAttachmentService.CommandHandler;

public readonly struct ChangeStatusPeyGiryAttachmentCommandHandler : IRequestHandler<ChangeStatusPeyGiryAttachmentCommand, PeyGiryAttachment?>
{
    private readonly IPeyGiryAttachmentRepository _repository;

    public ChangeStatusPeyGiryAttachmentCommandHandler(IPeyGiryAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PeyGiryAttachment?> Handle(ChangeStatusPeyGiryAttachmentCommand request,
        CancellationToken cancellationToken)
        => await _repository.ChangeStatusPeyGiryAttachmentByIdAsync(request);
}