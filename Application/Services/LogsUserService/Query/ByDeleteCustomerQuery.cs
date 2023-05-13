namespace Application.Services.LogsUserService.Query;

public struct ByDeleteCustomerQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}