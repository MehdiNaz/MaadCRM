namespace Application.Services.CustomersEmailAddressService.Commands;

public struct CreateCustomersEmailAddressCommand : IRequest<CustomersEmailAddress>
{
    public string EmailAddrs { get; set; }
}