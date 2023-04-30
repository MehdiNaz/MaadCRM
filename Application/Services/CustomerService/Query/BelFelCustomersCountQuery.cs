namespace Application.Services.CustomerService.Query;

public struct BelFelCustomersCountQuery : IRequest<Result<int>>
{
    public string UserId { get; set; }
}
