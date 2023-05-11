namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByLogIdHandler : IRequestHandler<ByLogIdQuery, Result<LogResponse>>
{
    private readonly ILogRepository _repository;

    public ByLogIdHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LogResponse>> Handle(ByLogIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteLogAsync(request.Id))
                .Match(result => new Result<LogResponse>(result),
                    exception => new Result<LogResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new Exception(e.Message));
        }
    }
}