namespace Application.Services.LogsUserService.Query;

public struct ByDeleteProductCategoryQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}