namespace Application.Services.CustomerService.Query;

public struct BelghovehCustomersCountQuery : IRequest<Result<int>>
{
    public string UserId { get; set; }
}
