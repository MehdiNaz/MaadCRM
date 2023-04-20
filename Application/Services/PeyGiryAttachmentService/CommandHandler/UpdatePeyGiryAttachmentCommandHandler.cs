namespace Application.Services.PeyGiryAttachmentService.CommandHandler;

public readonly struct UpdatePeyGiryAttachmentCommandHandler : IRequestHandler<UpdatePeyGiryAttachmentCommand, PeyGiryAttachment>
{
    private readonly IPeyGiryAttachmentRepository _repository;

    public UpdatePeyGiryAttachmentCommandHandler(IPeyGiryAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PeyGiryAttachment> Handle(UpdatePeyGiryAttachmentCommand request, CancellationToken cancellationToken)
    {
        UpdatePeyGiryAttachmentCommand item = new()
        {
            Id = request.Id,
            PeyGiryNoteId = request.PeyGiryNoteId,
            FileName = request.FileName,
            Extenstion = request.Extenstion
        };
        return await _repository.UpdatePeyGiryAttachmentAsync(item);
    }
}