namespace Application.Services.LogsUserService.Query;

public struct ByUpdateProductCategoryQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}