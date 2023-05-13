namespace Application.Services.LogsUserService.Query;

public struct ByInsertCustomerQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}