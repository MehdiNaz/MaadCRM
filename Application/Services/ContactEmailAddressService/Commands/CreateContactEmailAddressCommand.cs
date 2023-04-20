namespace Application.Services.ContactEmailAddressService.Commands;

public struct CreateContactEmailAddressCommand : IRequest<ContactsEmailAddress>
{ 
    public string EmailAddress { get; set; }
}