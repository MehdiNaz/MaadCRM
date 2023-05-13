namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByUpdateCustomerHandler : IRequestHandler<ByUpdateCustomerQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByUpdateCustomerHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByUpdateCustomerQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByUpdateCustomerAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}