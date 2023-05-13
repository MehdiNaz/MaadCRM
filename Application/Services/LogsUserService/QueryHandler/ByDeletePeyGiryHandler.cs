namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByDeletePeyGiryHandler : IRequestHandler<ByDeletePeyGiryQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByDeletePeyGiryHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByDeletePeyGiryQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByDeletePeyGiryAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}