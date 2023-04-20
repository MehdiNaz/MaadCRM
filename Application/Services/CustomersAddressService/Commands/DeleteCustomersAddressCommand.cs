namespace Application.Services.CustomersAddressService.Commands;

public struct DeleteCustomersAddressCommand: IRequest<CustomersAddress>
{
    public Ulid Id { get; set; }
}