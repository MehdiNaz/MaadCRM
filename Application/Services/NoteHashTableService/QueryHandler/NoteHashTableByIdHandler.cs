namespace Application.Services.NoteHashTableService.QueryHandler;

public readonly struct NoteHashTableByIdHandler : IRequestHandler<NoteHashTableByIdQuery, Result<CustomerNoteHashTable>>
{
    private readonly INoteHashTableRepository _repository;

    public NoteHashTableByIdHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTable>> Handle(NoteHashTableByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetNoteHashTableByIdAsync(request.Id))
                .Match(result => new Result<CustomerNoteHashTable>(result),
                exception => new Result<CustomerNoteHashTable>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new Exception(e.Message));
        }
    }
}