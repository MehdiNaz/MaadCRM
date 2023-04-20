namespace Application.Services.ContactEmailAddressService.Commands;

public struct DeleteContactEmailAddressCommand : IRequest<ContactsEmailAddress>
{
    public Ulid Id { get; set; }
}