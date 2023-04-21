namespace Application.Services.CustomersAddressService.Queries;

public struct CustomerAddressByIdQuery : IRequest<CustomerAddress>
{
    public Ulid CustomersAddressId { get; set; }
}