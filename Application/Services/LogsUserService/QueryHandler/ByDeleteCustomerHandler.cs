namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByDeleteCustomerHandler : IRequestHandler<ByDeleteCustomerQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByDeleteCustomerHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByDeleteCustomerQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByDeleteCustomerAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}