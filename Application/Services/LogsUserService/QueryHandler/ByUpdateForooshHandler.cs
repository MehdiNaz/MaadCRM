namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByUpdateForooshHandler : IRequestHandler<ByUpdateForooshQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByUpdateForooshHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByUpdateForooshQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByUpdateForooshAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}