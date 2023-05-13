namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByUpdateNoteHandler : IRequestHandler<ByUpdateNoteQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByUpdateNoteHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByUpdateNoteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByUpdateNoteAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}