namespace Application.Services.ContactEmailAddressService.Commands;

public struct UpdateContactEmailAddressCommand : IRequest<ContactsEmailAddress>
{
    public Ulid Id { get; set; }
    public string EmailAddress { get; set; }
}