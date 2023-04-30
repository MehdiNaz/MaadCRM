namespace Application.Services.CustomerService.Query;

public struct NaRazyCustomersCountQuery : IRequest<Result<int>>
{
    public string UserId { get; set; }
}
