namespace Application.Services.LogsUserService.Query;

public struct ByProductIdQuery : IRequest<Result<LogResponse>>
{
    public Ulid ProductId { get; set; }
}