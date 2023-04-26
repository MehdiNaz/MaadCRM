namespace Application.Interfaces.Contacts;

public interface IContactsEmailAddressRepository
{
    ValueTask<ICollection<ContactsEmailAddress?>> GetAllContactsEmailAddressAsync();
    ValueTask<ContactsEmailAddress?> GetContactsEmailAddressByIdAsync(Ulid requestId);
    ValueTask<ContactsEmailAddress?> ChangeStatusContactsEmailAddressByIdAsync(ChangeStatusContactEmailAddressCommand request);
    ValueTask<ContactsEmailAddress?> CreateContactsEmailAddressAsync(CreateContactEmailAddressCommand request);
    ValueTask<ContactsEmailAddress?> UpdateContactsEmailAddressAsync(UpdateContactEmailAddressCommand request);
    ValueTask<ContactsEmailAddress?> DeleteContactsEmailAddressAsync(Ulid id);
}