namespace Application.Services.PeyGiryAttachmentService.CommandHandler;

public class CreatePeyGiryAttachmentCommandHandler : IRequestHandler<CreatePeyGiryAttachmentCommand, PeyGiryAttachment>
{
    private readonly IPeyGiryAttachmentRepository _repository;

    public CreatePeyGiryAttachmentCommandHandler(IPeyGiryAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PeyGiryAttachment> Handle(CreatePeyGiryAttachmentCommand request, CancellationToken cancellationToken)
    {
        PeyGiryAttachment item = new()
        {
            PeyGiryNoteId = request.PeyGiryNoteId,
            FileName = request.FileName,
            Extenstion = request.Extenstion
        };
        await _repository.CreatePeyGiryAttachmentAsync(item);
        return item;
    }
}
