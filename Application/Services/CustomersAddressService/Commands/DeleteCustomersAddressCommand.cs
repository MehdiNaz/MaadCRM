namespace Application.Services.CustomersAddressService.Commands;

public struct DeleteCustomersAddressCommand: IRequest<CustomersAddress>
{
    public Ulid CustomersAddressId { get; set; }
}