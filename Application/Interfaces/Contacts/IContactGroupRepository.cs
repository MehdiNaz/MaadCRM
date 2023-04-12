namespace Application.Interfaces.Contacts;

public interface IContactGroupRepository
{
    ValueTask<ICollection<ContactGroup?>> GetAllContactGroupsAsync();
    ValueTask<ContactGroup?> GetContactGroupByIdAsync(Ulid contactGroupId);
    ValueTask<ContactGroup?> ChangeStateContactGroupAsync(Status status, Ulid contactGroupId);
    ValueTask<ContactGroup?> CreateContactGroupAsync(ContactGroup? entity);
    ValueTask<ContactGroup?> UpdateContactGroupAsync(ContactGroup entity, Ulid contactGroupId);
    ValueTask<ContactGroup?> DeleteContactGroupAsync(Ulid contactGroupId);
}
