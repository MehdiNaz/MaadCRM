namespace Application.Services.LogsUserService.Query;

public struct ByUpdateCustomerQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}