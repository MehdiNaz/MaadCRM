namespace Application.Services.NoteAttachmentService.CommandHandler;

public readonly struct ChangeStatusNoteAttachmentCommandHandler : IRequestHandler<ChangeStatusNoteAttachmentCommand, CustomerNoteAttachment?>
{
    private readonly INoteAttachmentRepository _repository;

    public ChangeStatusNoteAttachmentCommandHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteAttachment?> Handle(ChangeStatusNoteAttachmentCommand request,
        CancellationToken cancellationToken)
        => await _repository.ChangeStatusNoteAttachmentByIdAsync(request);
}