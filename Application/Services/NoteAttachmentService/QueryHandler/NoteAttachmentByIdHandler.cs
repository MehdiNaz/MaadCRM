namespace Application.Services.NoteAttachmentService.QueryHandler;

public readonly struct NoteAttachmentByIdHandler : IRequestHandler<NoteAttachmentByIdQuery, CustomerNoteAttachment>
{
    private readonly INoteAttachmentRepository _repository;

    public NoteAttachmentByIdHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteAttachment> Handle(NoteAttachmentByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetNoteAttachmentByIdAsync(request.NoteAttachmentId))!;
}