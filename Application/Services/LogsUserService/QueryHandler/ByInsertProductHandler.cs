﻿namespace Application.Services.LogsUserService.QueryHandler;

public readonly struct ByInsertProductHandler : IRequestHandler<ByInsertProductQuery, Result<ICollection<LogResponse>>>
{
    private readonly ILogRepository _repository;

    public ByInsertProductHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<LogResponse>>> Handle(ByInsertProductQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetLogsByInsertProductAsync(request.Type))
                .Match(result => new Result<ICollection<LogResponse>>(result),
                    exception => new Result<ICollection<LogResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<LogResponse>>(new Exception(e.Message));
        }
    }
}