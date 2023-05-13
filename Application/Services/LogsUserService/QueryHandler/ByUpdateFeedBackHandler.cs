namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByUpdateFeedBackHandler : IRequestHandler<ByUpdateFeedBackQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByUpdateFeedBackHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByUpdateFeedBackQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByUpdateFeedBackAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}