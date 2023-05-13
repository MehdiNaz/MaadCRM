namespace Application.Services.LogsUserService.Query;

public struct ByInsertProductQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}