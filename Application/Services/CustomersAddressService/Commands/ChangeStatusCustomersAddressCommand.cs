namespace Application.Services.CustomersAddressService.Commands;

public struct ChangeStatusCustomersAddressCommand : IRequest<CustomerAddress?>
{
    public Ulid Id { get; set; }
    public Status CustomersAddressStatus { get; set; }
}