namespace Application.Services.LogsUserService.Query;

public struct ByUpdateFeedBackQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}