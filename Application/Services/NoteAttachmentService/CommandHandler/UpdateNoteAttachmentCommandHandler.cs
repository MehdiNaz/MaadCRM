namespace Application.Services.NoteAttachmentService.CommandHandler;

public readonly struct UpdateNoteAttachmentCommandHandler : IRequestHandler<UpdateNoteAttachmentCommand, CustomerNoteAttachment>
{
    private readonly INoteAttachmentRepository _repository;

    public UpdateNoteAttachmentCommandHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteAttachment> Handle(UpdateNoteAttachmentCommand request, CancellationToken cancellationToken)
    {
        UpdateNoteAttachmentCommand item = new()
        {
            Id = request.Id,
            CustomerNoteId = request.CustomerNoteId,
            FileName = request.FileName,
            Extenstion = request.Extenstion
        };
        return await _repository.UpdateNoteAttachmentAsync(item);
    }
}