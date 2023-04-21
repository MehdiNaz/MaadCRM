namespace Application.Services.NoteHashTagService.QueryHandler;

public readonly struct AllNoteHashTagHandler : IRequestHandler<AllNoteHashTagQuery, ICollection<CustomerNoteHashTag>>
{
    private readonly INoteHashTagRepository _repository;

    public AllNoteHashTagHandler(INoteHashTagRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerNoteHashTag>> Handle(AllNoteHashTagQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllNoteHashTagsAsync())!;
}