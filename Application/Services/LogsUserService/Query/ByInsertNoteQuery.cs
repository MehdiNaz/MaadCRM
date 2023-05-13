namespace Application.Services.LogsUserService.Query;

public struct ByInsertNoteQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public LogTypes Type { get; set; }
}