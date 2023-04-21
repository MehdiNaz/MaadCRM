namespace Application.Services.CustomersAddressService.Queries;

public struct AllCustomerAddressQuery : IRequest<ICollection<CustomerAddress>>
{
    public Ulid CustomerId { get; set; }
}