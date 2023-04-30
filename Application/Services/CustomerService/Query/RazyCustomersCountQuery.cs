namespace Application.Services.CustomerService.Query;

public struct RazyCustomersCountQuery : IRequest<Result<int>>
{
    public string UserId { get; set; }
}
