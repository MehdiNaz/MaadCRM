namespace Application.Services.NoteAttachmentService.QueryHandler;

public class GetAllNoteAttachmentHandler : IRequestHandler<GetAllNoteAttachmentQuery, ICollection<NoteAttachment>>
{
    private readonly INoteAttachmentRepository _repository;

    public GetAllNoteAttachmentHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<NoteAttachment>> Handle(GetAllNoteAttachmentQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllNoteAttachmentsAsync())!;
}