namespace Application.Services.ContactEmailAddressService.Queries;

public struct GetContactsEmailAddressByIdQuery : IRequest<ContactsEmailAddress>
{
    public Ulid ContactsEmailAddressId { get; set; }
}