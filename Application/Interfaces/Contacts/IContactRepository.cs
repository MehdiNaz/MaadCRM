namespace Application.Interfaces.Contacts;

public interface IContactRepository
{
    ValueTask<Result<ICollection<ContactsResponse>>> GetAllContactAsync();
    ValueTask<Result<ContactsResponse>> GetContactByIdAsync(Ulid contactId);
    ValueTask<Result<ICollection<ContactsResponse>>> GetContactByGroupIdAsync(Ulid contactGroupId);
    ValueTask<Result<ContactsResponse>> ChangeStatusContactByIdAsync(ChangeStatusContactCommand request);
    ValueTask<Result<ICollection<ContactsResponse>>> SearchContactAsync(string q);
    ValueTask<Result<ContactsResponse>> CreateContactAsync(CreateContactCommand entity);
    ValueTask<Result<ContactsResponse>> UpdateContactAsync(UpdateContactCommand entity);
    ValueTask<Result<ContactsResponse>> DeleteContactAsync(Ulid id);
}