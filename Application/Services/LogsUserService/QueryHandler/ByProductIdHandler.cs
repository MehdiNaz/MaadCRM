namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByProductIdHandler : IRequestHandler<ByProductIdQuery, Result<LogResponse>>
{
    private readonly ILogRepository _repository;

    public ByProductIdHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LogResponse>> Handle(ByProductIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetByProductIdAsync(request.ProductId))
                .Match(result => new Result<LogResponse>(result),
                    exception => new Result<LogResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new Exception(e.Message));
        }
    }
}