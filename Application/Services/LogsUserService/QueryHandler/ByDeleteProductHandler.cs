namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByDeleteProductHandler : IRequestHandler<ByDeleteProductQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByDeleteProductHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByDeleteProductQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByDeleteProductAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}