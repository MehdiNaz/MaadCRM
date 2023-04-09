namespace Application.Services.NoteHashTagService.QueryHandler;

public readonly struct NoteHashTagByIdHandler : IRequestHandler<NoteHashTagByIdQuery, NoteHashTag>
{
    private readonly INoteHashTagRepository _repository;

    public NoteHashTagByIdHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteHashTag> Handle(NoteHashTagByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetNoteHashTagByIdAsync(request.NoteHashTagId))!;
}