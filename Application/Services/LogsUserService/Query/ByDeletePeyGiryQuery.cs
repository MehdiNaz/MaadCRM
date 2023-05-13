namespace Application.Services.LogsUserService.Query;

public struct ByDeletePeyGiryQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}