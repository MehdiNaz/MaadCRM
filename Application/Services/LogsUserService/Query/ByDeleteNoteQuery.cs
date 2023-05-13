namespace Application.Services.LogsUserService.Query;

public struct ByDeleteNoteQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}