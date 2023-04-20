namespace Application.Services.ContactEmailAddressService.Queries;

public struct GetContactsEmailAddressByIdQuery : IRequest<ContactsEmailAddress>
{
    public Ulid Id { get; set; }
}