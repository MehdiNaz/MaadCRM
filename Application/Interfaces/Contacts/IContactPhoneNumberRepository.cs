namespace Application.Interfaces.Contacts;

public interface IContactPhoneNumberRepository
{
    ValueTask<ICollection<ContactPhoneNumber?>> GetAllContactPhoneNumberAsync();
    ValueTask<ContactPhoneNumber?> GetContactPhoneNumberByIdAsync(Ulid contactPhoneNumberId);
    ValueTask<ContactPhoneNumber?> CreateContactPhoneNumberAsync(ContactPhoneNumber? entity);
    ValueTask<ContactPhoneNumber?> UpdateContactPhoneNumberAsync(ContactPhoneNumber entity, Ulid contactPhoneNumberId);
    ValueTask<ContactPhoneNumber?> DeleteContactPhoneNumberAsync(Ulid contactPhoneNumberId);
}