namespace Application.Services.CustomerService.Query;

public struct AllCustomersQuery : IRequest<ICollection<CustomerResponse>>
{
    public string UserId { get; set; }
}