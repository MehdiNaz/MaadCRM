namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByForooshIdHandler : IRequestHandler<ByForooshIdQuery, Result<LogResponse>>
{
    private readonly ILogRepository _repository;

    public ByForooshIdHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LogResponse>> Handle(ByForooshIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetByForooshIdAsync(request.ForooshId))
                .Match(result => new Result<LogResponse>(result),
                    exception => new Result<LogResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new Exception(e.Message));
        }
    }
}