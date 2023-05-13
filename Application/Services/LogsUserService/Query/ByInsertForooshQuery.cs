namespace Application.Services.LogsUserService.Query;

public struct ByInsertForooshQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}