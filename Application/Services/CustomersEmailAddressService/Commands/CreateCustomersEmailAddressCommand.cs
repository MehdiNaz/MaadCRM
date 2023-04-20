namespace Application.Services.CustomersEmailAddressService.Commands;

public struct CreateCustomersEmailAddressCommand : IRequest<CustomersEmailAddress>
{
    public string EmailAddress { get; set; }
    public Ulid CustomerId { get; set; }
}