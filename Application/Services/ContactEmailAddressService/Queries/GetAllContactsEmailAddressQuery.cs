namespace Application.Services.ContactEmailAddressService.Queries;

public struct GetAllContactsEmailAddressQuery : IRequest<ContactsEmailAddress>, IRequest<ICollection<ContactsEmailAddress?>>
{
}