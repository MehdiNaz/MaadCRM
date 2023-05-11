namespace Application.Services.LogsUserService.Query;

public struct ByLogIdQuery : IRequest<Result<LogResponse>>
{
    public Ulid Id { get; set; }
}