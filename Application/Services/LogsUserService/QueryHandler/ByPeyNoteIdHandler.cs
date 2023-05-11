namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByPeyNoteIdHandler : IRequestHandler<ByPeyGiryIdQuery, Result<LogResponse>>
{
    private readonly ILogRepository _repository;

    public ByPeyNoteIdHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LogResponse>> Handle(ByPeyGiryIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetByPeyGiryIdAsync(request.PeyGiryId))
                .Match(result => new Result<LogResponse>(result),
                    exception => new Result<LogResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new Exception(e.Message));
        }
    }
}