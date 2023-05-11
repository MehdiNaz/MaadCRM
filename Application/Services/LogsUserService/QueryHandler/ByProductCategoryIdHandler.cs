namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByProductCategoryIdHandler : IRequestHandler<ByProductCategoryIdQuery, Result<LogResponse>>
{
    private readonly ILogRepository _repository;

    public ByProductCategoryIdHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LogResponse>> Handle(ByProductCategoryIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetByProductCategoryIdAsync(request.ProductCategoryId))
                .Match(result => new Result<LogResponse>(result),
                    exception => new Result<LogResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new Exception(e.Message));
        }
    }
}