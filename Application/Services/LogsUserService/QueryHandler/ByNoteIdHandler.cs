namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByNoteIdHandler : IRequestHandler<ByPeyGiryIdQuery, Result<LogResponse>>
{
    private readonly ILogRepository _repository;

    public ByNoteIdHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LogResponse>> Handle(ByPeyGiryIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetByNoteIdAsync(request.PeyGiryId))
                .Match(result => new Result<LogResponse>(result),
                    exception => new Result<LogResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new Exception(e.Message));
        }
    }
}