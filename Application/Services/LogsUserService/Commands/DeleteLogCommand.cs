namespace Application.Services.LogsUserService.Commands;

public struct DeleteLogCommand : IRequest<Result<LogResponse>>
{
    public Ulid Id { get; set; }
}