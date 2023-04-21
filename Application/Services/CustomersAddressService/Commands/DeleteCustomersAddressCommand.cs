namespace Application.Services.CustomersAddressService.Commands;

public struct DeleteCustomersAddressCommand: IRequest<CustomerAddress>
{
    public Ulid Id { get; set; }
}