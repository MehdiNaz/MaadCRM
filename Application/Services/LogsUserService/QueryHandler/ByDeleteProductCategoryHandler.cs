namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByDeleteProductCategoryHandler : IRequestHandler<ByDeleteProductCategoryQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByDeleteProductCategoryHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByDeleteProductCategoryQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByDeleteProductCategoryAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}