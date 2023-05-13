namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByInsertNoteHandler : IRequestHandler<ByInsertNoteQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByInsertNoteHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByInsertNoteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByInsertNoteAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}