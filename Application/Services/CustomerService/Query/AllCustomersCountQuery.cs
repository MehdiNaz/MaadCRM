namespace Application.Services.CustomerService.Query;

public struct AllCustomersCountQuery : IRequest<Result<int>>
{
    public string UserId { get; set; }
}
