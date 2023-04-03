namespace Application.Services.NoteAttachmentService.CommandHandler;

public class DeleteNoteAttachmentCommandHandler : IRequestHandler<DeleteNoteAttachmentCommand, NoteAttachment>
{
    private readonly INoteAttachmentRepository _repository;

    public DeleteNoteAttachmentCommandHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteAttachment> Handle(DeleteNoteAttachmentCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteNoteAttachmentAsync(request.NoteAttachmentId))!;
}