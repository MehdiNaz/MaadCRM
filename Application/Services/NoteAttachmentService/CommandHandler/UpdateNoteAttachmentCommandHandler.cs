namespace Application.Services.NoteAttachmentService.CommandHandler;

public class UpdateNoteAttachmentCommandHandler : IRequestHandler<UpdateNoteAttachmentCommand, NoteAttachment>
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
            CustomerNoteId = request.CustomerNoteId,
            FileName = request.FileName,
            Extenstion = request.Extenstion
        };
        await _repository.UpdateNoteAttachmentAsync(item, request.NoteAttachmentId);
        return item;
    }
}