namespace Application.Services.CustomersAddressService.Queries;

public struct AllCustomerAddressQuery : IRequest<ICollection<CustomersAddress>>
{
    public Ulid CustomerId { get; set; }
}