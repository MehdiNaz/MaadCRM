namespace Application.Services.CustomersEmailAddressService.Commands;

public struct DeleteCustomersEmailAddressCommand : IRequest<CustomersEmailAddress>
{
    public Ulid EmailAddressId { get; set; }
}