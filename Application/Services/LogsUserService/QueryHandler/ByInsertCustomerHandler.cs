namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByInsertCustomerHandler : IRequestHandler<ByInsertCustomerQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByInsertCustomerHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByInsertCustomerQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByInsertCustomerAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}