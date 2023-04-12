namespace Application.Services.CustomersAddressService.Commands;

public struct ChangeStatusCustomersAddressCommand : IRequest<CustomersAddress?>
{
    public Ulid CustomersAddressId { get; set; }
    public Status CustomersAddressStatus { get; set; }
}