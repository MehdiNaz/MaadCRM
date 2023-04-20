namespace Application.Services.NoteAttachmentService.CommandHandler;

public readonly struct ChangeStatusNoteAttachmentCommandHandler : IRequestHandler<ChangeStatusNoteAttachmentCommand, NoteAttachment?>
{
    private readonly INoteAttachmentRepository _repository;

    public ChangeStatusNoteAttachmentCommandHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteAttachment?> Handle(ChangeStatusNoteAttachmentCommand request,
        CancellationToken cancellationToken)
        => await _repository.ChangeStatusNoteAttachmentByIdAsync(request);
}