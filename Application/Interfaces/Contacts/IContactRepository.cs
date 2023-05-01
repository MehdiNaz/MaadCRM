namespace Application.Interfaces.Contacts;

public interface IContactRepository
{
    ValueTask<Result<ICollection<Contact>>> GetAllContactAsync();
    ValueTask<Result<Contact>> GetContactByIdAsync(Ulid contactId);
    ValueTask<Result<Contact>> ChangeStatusContactByIdAsync(ChangeStatusContactCommand request);
    ValueTask<Result<Contact>> CreateContactAsync(CreateContactCommand entity);
    ValueTask<Result<Contact>> UpdateContactAsync(UpdateContactCommand entity);
    ValueTask<Result<Contact>> DeleteContactAsync(Ulid id);
}