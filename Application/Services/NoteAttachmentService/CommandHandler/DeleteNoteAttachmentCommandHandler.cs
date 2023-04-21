namespace Application.Services.NoteAttachmentService.CommandHandler;

public readonly struct DeleteNoteAttachmentCommandHandler : IRequestHandler<DeleteNoteAttachmentCommand, CustomerNoteAttachment>
{
    private readonly INoteAttachmentRepository _repository;

    public DeleteNoteAttachmentCommandHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteAttachment> Handle(DeleteNoteAttachmentCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteNoteAttachmentAsync(request))!;
}