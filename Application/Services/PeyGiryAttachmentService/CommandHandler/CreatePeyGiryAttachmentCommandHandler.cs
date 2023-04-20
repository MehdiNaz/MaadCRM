namespace Application.Services.PeyGiryAttachmentService.CommandHandler;

public readonly struct CreatePeyGiryAttachmentCommandHandler : IRequestHandler<CreatePeyGiryAttachmentCommand, PeyGiryAttachment>
{
    private readonly IPeyGiryAttachmentRepository _repository;

    public CreatePeyGiryAttachmentCommandHandler(IPeyGiryAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PeyGiryAttachment> Handle(CreatePeyGiryAttachmentCommand request, CancellationToken cancellationToken)
    {
        CreatePeyGiryAttachmentCommand item = new()
        {
            PeyGiryNoteId = request.PeyGiryNoteId,
            FileName = request.FileName,
            Extenstion = request.Extenstion
        };
       return await _repository.CreatePeyGiryAttachmentAsync(item);
    }
}
