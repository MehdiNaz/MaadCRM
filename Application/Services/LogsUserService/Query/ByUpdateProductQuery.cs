namespace Application.Services.LogsUserService.Query;

public struct ByUpdateProductQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}