namespace Application.Services.LogsUserService.Query;

public struct ByInsertPeyGiryQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}