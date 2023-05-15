﻿namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct AllLogsHandler : IRequestHandler<AllLogsQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public AllLogsHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(AllLogsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllLogsAsync())
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}