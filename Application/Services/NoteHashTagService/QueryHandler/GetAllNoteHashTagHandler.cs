namespace Application.Services.NoteHashTagService.QueryHandler;

public class GetAllNoteHashTagHandler : IRequestHandler<GetAllNoteHashTagQuery, ICollection<NoteHashTag>>
{
    private readonly INoteHashTagRepository _repository;

    public GetAllNoteHashTagHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<NoteHashTag>> Handle(GetAllNoteHashTagQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllNoteHashTagsAsync())!;
}