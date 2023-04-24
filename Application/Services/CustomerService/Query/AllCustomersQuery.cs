namespace Application.Services.CustomerService.Query;

public struct AllCustomersQuery : IRequest<Result<ICollection<CustomerResponse>>>
{
    public string UserId { get; set; }
}