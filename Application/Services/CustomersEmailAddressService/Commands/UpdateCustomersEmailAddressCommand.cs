namespace Application.Services.CustomersEmailAddressService.Commands;

public struct UpdateCustomersEmailAddressCommand : IRequest<CustomersEmailAddress>
{
    public Ulid Id { get; set; }
    public string EmailAddress { get; set; }
    public Ulid CustomerId { get; set; }
}