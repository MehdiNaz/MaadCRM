namespace Application.Services.CustomersEmailAddressService.Commands;

public struct UpdateCustomersEmailAddressCommand : IRequest<CustomersEmailAddress>
{
    public Ulid EmailAddressId { get; set; }
    public string EmailAddrs { get; set; }
}