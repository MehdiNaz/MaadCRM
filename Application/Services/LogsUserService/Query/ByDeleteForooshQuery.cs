namespace Application.Services.LogsUserService.Query;

public struct ByDeleteForooshQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}