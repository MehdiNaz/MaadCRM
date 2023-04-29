namespace Application.Services.NoteHashTableService.QueryHandler;

public readonly struct AllNoteHashTableHandler : IRequestHandler<AllNoteHashTableQuery, Result<ICollection<CustomerNoteHashTable>>>
{
    private readonly INoteHashTableRepository _repository;

    public AllNoteHashTableHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerNoteHashTable>>> Handle(AllNoteHashTableQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllNoteHashTablesAsync(request.BusinessId))
                .Match(result => new Result<ICollection<CustomerNoteHashTable>>(result),
                exception => new Result<ICollection<CustomerNoteHashTable>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerNoteHashTable>>(new Exception(e.Message));
        }
    }
}