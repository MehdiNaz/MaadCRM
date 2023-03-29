namespace Application.Interfaces.Contacts;

public interface IContactsEmailAddressRepository
{
    ValueTask<ICollection<ContactsEmailAddress?>> GetAllContactsEmailAddressAsync();
    ValueTask<ContactsEmailAddress?> GetContactsEmailAddressByIdAsync(Ulid contactsEmailAddressId);
    ValueTask<ContactsEmailAddress?> CreateContactsEmailAddressAsync(ContactsEmailAddress? entity);
    ValueTask<ContactsEmailAddress?> UpdateContactsEmailAddressAsync(ContactsEmailAddress entity, Ulid contactsEmailAddressId);
    ValueTask<ContactsEmailAddress?> DeleteContactsEmailAddressAsync(Ulid contactsEmailAddressId);
}