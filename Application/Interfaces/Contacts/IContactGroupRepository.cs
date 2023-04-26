namespace Application.Interfaces.Contacts;

public interface IContactGroupRepository
{
    ValueTask<ICollection<ContactGroup?>> GetAllContactGroupsAsync();
    ValueTask<ContactGroup?> GetContactGroupByIdAsync(Ulid requestId);
    ValueTask<ContactGroup?> ChangeStatusContactGroupAsync(ChangeStatusContactGroupCommand request);
    ValueTask<ContactGroup?> CreateContactGroupAsync(CreateContactGroupCommand request);
    ValueTask<ContactGroup?> UpdateContactGroupAsync(UpdateContactGroupCommand request);
    ValueTask<ContactGroup?> DeleteContactGroupAsync(Ulid id);
}
