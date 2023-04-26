namespace Application.Interfaces.Contacts;

public interface IContactPhoneNumberRepository
{
    ValueTask<ICollection<ContactPhoneNumber?>> GetAllContactPhoneNumberAsync();
    ValueTask<ContactPhoneNumber?> GetContactPhoneNumberByIdAsync(Ulid contactPhoneNumberId);
    ValueTask<ContactPhoneNumber?> ChangeStatusContactPhoneNumberByIdAsync(ChangeStatusContactPhoneNumberCommand request);
    ValueTask<ContactPhoneNumber?> CreateContactPhoneNumberAsync(CreateContactPhoneNumberCommand request);
    ValueTask<ContactPhoneNumber?> UpdateContactPhoneNumberAsync(UpdateContactPhoneNumberCommand request);
    ValueTask<ContactPhoneNumber?> DeleteContactPhoneNumberAsync(Ulid id);
}