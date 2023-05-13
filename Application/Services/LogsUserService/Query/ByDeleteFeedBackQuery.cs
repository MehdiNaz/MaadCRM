namespace Application.Services.LogsUserService.Query;

public struct ByDeleteFeedBackQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}