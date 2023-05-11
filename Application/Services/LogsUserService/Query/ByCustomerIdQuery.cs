namespace Application.Services.LogsUserService.Query;

public struct ByCustomerIdQuery : IRequest<Result<LogResponse>>
{
    public Ulid CustomerId { get; set; }
}