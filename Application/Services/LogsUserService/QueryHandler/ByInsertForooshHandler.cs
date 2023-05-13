namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByInsertForooshHandler : IRequestHandler<ByInsertForooshQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByInsertForooshHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByInsertForooshQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByInsertForooshAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}