namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByDeleteFeedBackHandler : IRequestHandler<ByDeleteFeedBackQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByDeleteFeedBackHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByDeleteFeedBackQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByDeleteFeedBackAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}