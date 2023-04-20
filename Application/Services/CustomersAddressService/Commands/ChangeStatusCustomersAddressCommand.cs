namespace Application.Services.CustomersAddressService.Commands;

public struct ChangeStatusCustomersAddressCommand : IRequest<CustomersAddress?>
{
    public Ulid Id { get; set; }
    public Status CustomersAddressStatus { get; set; }
}