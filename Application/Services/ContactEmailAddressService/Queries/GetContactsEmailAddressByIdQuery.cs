namespace Application.Services.ContactEmailAddressService.Queries;

public class GetContactsEmailAddressByIdQuery : IRequest<ContactsEmailAddress>
{
    public Ulid ContactsEmailAddressId { get; set; }
}