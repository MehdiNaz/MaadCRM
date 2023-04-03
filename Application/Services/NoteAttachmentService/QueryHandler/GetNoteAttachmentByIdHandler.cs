namespace Application.Services.NoteAttachmentService.QueryHandler;

public class GetNoteAttachmentByIdHandler : IRequestHandler<GetNoteAttachmentByIdQuery, NoteAttachment>
{
    private readonly INoteAttachmentRepository _repository;

    public GetNoteAttachmentByIdHandler(INoteAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteAttachment> Handle(GetNoteAttachmentByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetNoteAttachmentByIdAsync(request.NoteAttachmentId))!;
}