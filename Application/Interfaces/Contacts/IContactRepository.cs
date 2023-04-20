namespace Application.Interfaces.Contacts;

public interface IContactRepository
{
    ValueTask<ICollection<Contact?>> GetAllContactAsync();
    ValueTask<Contact?> GetContactByIdAsync(Ulid contactId);
    ValueTask<Contact?> ChangeStatusContactByIdAsync(ChangeStatusContactCommand request);
    ValueTask<Contact?> CreateContactAsync(CreateContactCommand entity);
    ValueTask<Contact?> UpdateContactAsync(UpdateContactCommand entity);
    ValueTask<Contact?> DeleteContactAsync(DeleteContactCommand entity);
}