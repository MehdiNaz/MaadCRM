namespace Application.Services.CustomerService.Query;

public struct AllCustomersQuery : IRequest<ICollection<Customer?>>
{
    public string UserId { get; set; }
}