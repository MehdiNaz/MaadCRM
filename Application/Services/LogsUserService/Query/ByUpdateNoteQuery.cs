namespace Application.Services.LogsUserService.Query;

public struct ByUpdateNoteQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}