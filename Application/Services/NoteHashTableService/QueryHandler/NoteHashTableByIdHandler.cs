namespace Application.Services.NoteHashTableService.QueryHandler;

public readonly struct NoteHashTableByIdHandler : IRequestHandler<NoteHashTableByIdQuery, Result<CustomerNoteHashTableResponse>>
{
    private readonly INoteHashTableRepository _repository;

    public NoteHashTableByIdHandler(INoteHashTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTableResponse>> Handle(NoteHashTableByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetNoteHashTableByIdAsync(request.Id))
                .Match(result => new Result<CustomerNoteHashTableResponse>(result),
                exception => new Result<CustomerNoteHashTableResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new Exception(e.Message));
        }
    }
}