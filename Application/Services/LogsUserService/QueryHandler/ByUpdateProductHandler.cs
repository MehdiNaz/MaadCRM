namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByUpdateProductHandler : IRequestHandler<ByUpdateProductQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByUpdateProductHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByUpdateProductQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByUpdateProductAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}