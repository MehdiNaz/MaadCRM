namespace Application.Services.Customer.CustomerService.Query;

public struct AllCustomersQuery : IRequest<Result<ICollection<CustomerResponse>>>
{
    public string UserId { get; set; }
}