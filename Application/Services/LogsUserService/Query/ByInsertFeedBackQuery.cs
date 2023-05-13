namespace Application.Services.LogsUserService.Query;

public struct ByInsertFeedBackQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}