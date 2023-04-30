namespace Application.Services.CustomerService.Query;

public struct VafadarCustomersCountQuery : IRequest<Result<int>>
{
    public string UserId { get; set; }
}
