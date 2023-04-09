namespace Application.Services.NoteAttachmentService.CommandHandler;

public readonly struct CreateNoteAttachmentCommandHandler : IRequestHandler<CreateNoteAttachmentCommand, NoteAttachment>
{
    private readonly INoteAttachmentRepository _repository;

    public CreateNoteAttachmentCommandHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteAttachment> Handle(CreateNoteAttachmentCommand request, CancellationToken cancellationToken)
    {
        NoteAttachment item = new()
        {
            CustomerNoteId = request.CustomerNoteId,
            FileName = request.FileName,
            Extenstion = request.Extenstion
        };
        await _repository.CreateNoteAttachmentAsync(item);
        return item;
    }
}
