namespace Application.Services.LogsUserService.Query;

public struct ByUpdateForooshQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}