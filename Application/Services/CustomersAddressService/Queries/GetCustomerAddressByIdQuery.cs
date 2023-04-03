namespace Application.Services.CustomersAddressService.Queries;

public struct GetCustomerAddressByIdQuery : IRequest<CustomersAddress>
{
    public Ulid CustomersAddressId { get; set; }
}