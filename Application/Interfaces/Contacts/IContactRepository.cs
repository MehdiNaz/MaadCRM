namespace Application.Interfaces.Contacts;

public interface IContactRepository
{
    ValueTask<ICollection<Contact?>> GetAllContactAsync();
    ValueTask<Contact?> GetContactByIdAsync(Ulid contactId);
    ValueTask<Contact?> ChangeStateContactByIdAsync(Status status, Ulid contactId);
    ValueTask<Contact?> CreateContactAsync(Contact? entity);
    ValueTask<Contact?> UpdateContactAsync(Contact entity, Ulid contactId);
    ValueTask<Contact?> DeleteContactAsync(Ulid contactId);
}