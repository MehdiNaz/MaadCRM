namespace Application.Services.ContactEmailAddressService.Commands;

public class CreateContactEmailAddressCommand : IRequest<ContactsEmailAddress>
{ 
    public string CustomersEmailAddrs { get; set; }
}