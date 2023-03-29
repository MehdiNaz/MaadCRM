namespace Application.Services.ContactEmailAddressService.Commands;

public struct UpdateContactEmailAddressCommand : IRequest<ContactsEmailAddress>
{
    public Ulid CustomersEmailAddressId { get; set; }
    public string CustomersEmailAddrs { get; set; }
}