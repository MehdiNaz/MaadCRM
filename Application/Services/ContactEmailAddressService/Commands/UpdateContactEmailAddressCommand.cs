namespace Application.Services.ContactEmailAddressService.Commands;

public class UpdateContactEmailAddressCommand : IRequest<ContactsEmailAddress>
{
    public Ulid CustomersEmailAddressId { get; set; }
    public string CustomersEmailAddrs { get; set; }
}