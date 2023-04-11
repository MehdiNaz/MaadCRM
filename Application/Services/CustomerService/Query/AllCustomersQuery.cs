namespace Application.Services.CustomerService.Query;

public struct AllCustomersQuery : IRequest<ICollection<Customer?>>
{
    public Ulid CustomerId { get; set; }
}