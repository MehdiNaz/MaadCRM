namespace Application.Services.NoteAttachmentService.CommandHandler;

public readonly struct CreateNoteAttachmentCommandHandler : IRequestHandler<CreateNoteAttachmentCommand, CustomerNoteAttachment>
{
    private readonly INoteAttachmentRepository _repository;

    public CreateNoteAttachmentCommandHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteAttachment> Handle(CreateNoteAttachmentCommand request, CancellationToken cancellationToken)
    {
        CreateNoteAttachmentCommand item = new()
        {
            CustomerNoteId = request.CustomerNoteId,
            FileName = request.FileName,
            Extenstion = request.Extenstion
        };
        return await _repository.CreateNoteAttachmentAsync(item);
    }
}
