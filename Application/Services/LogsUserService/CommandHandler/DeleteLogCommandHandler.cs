namespace Application.Services.LogsUserService.CommandHandler;

public readonly struct DeleteLogCommandHandler : IRequestHandler<DeleteLogCommand, Result<LogResponse>>
{
    private readonly ILogRepository _repository;

    public DeleteLogCommandHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LogResponse>> Handle(DeleteLogCommand request, CancellationToken cancellationToken)
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