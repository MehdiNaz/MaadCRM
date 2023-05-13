namespace Application.Services.LogsUserService.Query;

public struct ByDeleteProductQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}