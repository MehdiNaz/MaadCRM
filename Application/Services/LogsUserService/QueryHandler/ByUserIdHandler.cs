namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByUserIdHandler : IRequestHandler<ByUserIdQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByUserIdHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByUserIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByUserIdAsync(request.UserId))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}