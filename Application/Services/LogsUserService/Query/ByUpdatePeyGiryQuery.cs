namespace Application.Services.LogsUserService.Query;

public struct ByUpdatePeyGiryQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}