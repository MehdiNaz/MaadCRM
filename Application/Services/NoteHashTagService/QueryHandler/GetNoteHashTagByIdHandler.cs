namespace Application.Services.NoteHashTagService.QueryHandler;

public class GetNoteHashTagByIdHandler : IRequestHandler<GetNoteHashTagByIdQuery, NoteHashTag>
{
    private readonly INoteHashTagRepository _repository;

    public GetNoteHashTagByIdHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteHashTag> Handle(GetNoteHashTagByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetNoteHashTagByIdAsync(request.NoteHashTagId))!;
}