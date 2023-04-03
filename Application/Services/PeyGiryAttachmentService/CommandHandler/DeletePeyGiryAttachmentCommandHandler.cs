namespace Application.Services.PeyGiryAttachmentService.CommandHandler;

public class DeletePeyGiryAttachmentCommandHandler : IRequestHandler<DeletePeyGiryAttachmentCommand, PeyGiryAttachment>
{
    private readonly IPeyGiryAttachmentRepository _repository;

    public DeletePeyGiryAttachmentCommandHandler(IPeyGiryAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PeyGiryAttachment> Handle(DeletePeyGiryAttachmentCommand request, CancellationToken cancellationToken)
        => (await _repository.DeletePeyGiryAttachmentAsync(request.PeyGiryAttachmentId))!;
}