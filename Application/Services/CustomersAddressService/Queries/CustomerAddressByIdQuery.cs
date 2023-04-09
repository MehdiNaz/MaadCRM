namespace Application.Services.CustomersAddressService.Queries;

public struct CustomerAddressByIdQuery : IRequest<CustomersAddress>
{
    public Ulid CustomersAddressId { get; set; }
}