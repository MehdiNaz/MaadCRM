namespace Application.Services.LogsUserService.Query;

public struct ByForooshIdQuery : IRequest<Result<LogResponse>>
{
    public Ulid ForooshId { get; set; }
}