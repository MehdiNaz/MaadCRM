namespace Application.Services.NoteAttachmentService.CommandHandler;

public readonly struct UpdateNoteAttachmentCommandHandler : IRequestHandler<UpdateNoteAttachmentCommand, NoteAttachment>
{
    private readonly INoteAttachmentRepository _repository;

    public UpdateNoteAttachmentCommandHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteAttachment> Handle(UpdateNoteAttachmentCommand request, CancellationToken cancellationToken)
    {
        NoteAttachment item = new()
        {
            NoteAttachmentId = request.NoteAttachmentId,
            CustomerNoteId = request.CustomerNoteId,
            FileName = request.FileName,
            Extenstion = request.Extenstion
        };
        await _repository.UpdateNoteAttachmentAsync(item);
        return item;
    }
}