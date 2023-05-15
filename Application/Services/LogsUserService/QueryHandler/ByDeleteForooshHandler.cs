﻿namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByDeleteForooshHandler : IRequestHandler<ByDeleteForooshQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByDeleteForooshHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByDeleteForooshQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByDeleteForooshAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}