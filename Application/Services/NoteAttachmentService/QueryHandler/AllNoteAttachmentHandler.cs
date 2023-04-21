namespace Application.Services.NoteAttachmentService.QueryHandler;

public readonly struct AllNoteAttachmentHandler : IRequestHandler<AllNoteAttachmentQuery, ICollection<CustomerNoteAttachment>>
{
    private readonly INoteAttachmentRepository _repository;

    public AllNoteAttachmentHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerNoteAttachment>> Handle(AllNoteAttachmentQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllNoteAttachmentsAsync())!;
}