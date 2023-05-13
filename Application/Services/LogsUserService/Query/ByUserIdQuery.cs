namespace Application.Services.LogsUserService.Query;

public struct ByUserIdQuery : IRequest<Result<ICollection<LogResponse>>>
{
    public string UserId { get; set; }
}