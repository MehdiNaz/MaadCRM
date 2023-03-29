namespace Application.Services.ContactEmailAddressService.Commands;

public struct CreateContactEmailAddressCommand : IRequest<ContactsEmailAddress>
{ 
    public string CustomersEmailAddrs { get; set; }
}