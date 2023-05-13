namespace Application.Services.LogsUserService.Query;

public struct ByInsertProductCategoryQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}