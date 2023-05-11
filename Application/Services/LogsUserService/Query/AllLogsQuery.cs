namespace Application.Services.LogsUserService.Query;

public struct AllLogsQuery : IRequest<Result<ICollection<LogResponse>>>
{
}