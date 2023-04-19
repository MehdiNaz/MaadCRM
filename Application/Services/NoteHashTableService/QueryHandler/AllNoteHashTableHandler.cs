namespace Application.Services.NoteHashTableService.QueryHandler;

public readonly struct AllNoteHashTableHandler : IRequestHandler<AllNoteHashTableQuery, ICollection<NoteHashTable>>
{
    private readonly INoteHashTableRepository _repository;

    public AllNoteHashTableHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<NoteHashTable>> Handle(AllNoteHashTableQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllNoteHashTablesAsync(request.BusinessId);
}