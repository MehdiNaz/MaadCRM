namespace Application.Services.LogsUserService.Query;

public struct ByPeyNoteIdQuery : IRequest<Result<LogResponse>>
{
    public Ulid PeyNoteId { get; set; }
}