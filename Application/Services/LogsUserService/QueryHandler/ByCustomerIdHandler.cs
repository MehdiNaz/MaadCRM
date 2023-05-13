namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByCustomerIdHandler : IRequestHandler<ByCustomerIdQuery, Result<LogResponse>>
{
    private readonly ILogRepository _repository;

    public ByCustomerIdHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LogResponse>> Handle(ByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetByCustomerIdAsync(request.CustomerId))
                .Match(result => new Result<LogResponse>(result),
                    exception => new Result<LogResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new Exception(e.Message));
        }
    }
}