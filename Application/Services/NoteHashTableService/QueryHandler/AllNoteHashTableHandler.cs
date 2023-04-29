namespace Application.Services.NoteHashTableService.QueryHandler;

public readonly struct AllNoteHashTableHandler : IRequestHandler<AllNoteHashTableQuery, Result<ICollection<CustomerNoteHashTableResponse>>>
{
    private readonly INoteHashTableRepository _repository;

    public AllNoteHashTableHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerNoteHashTableResponse>>> Handle(AllNoteHashTableQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllNoteHashTablesAsync(request.BusinessId))
                .Match(result => new Result<ICollection<CustomerNoteHashTableResponse>>(result),
                exception => new Result<ICollection<CustomerNoteHashTableResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerNoteHashTableResponse>>(new Exception(e.Message));
        }
    }
}