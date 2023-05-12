namespace Application.Services.LogsUserService.Query;

public struct ByNoteIdQuery : IRequest<Result<LogResponse>>
{
    public Ulid PeyNoteId { get; set; }
}