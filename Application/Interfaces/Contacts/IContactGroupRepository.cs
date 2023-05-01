﻿namespace Application.Interfaces.Contacts;

public interface IContactGroupRepository
{
    ValueTask<Result<ICollection<ContactGroup>>> GetAllContactGroupsAsync();
    ValueTask<Result<ContactGroup>> GetContactGroupByIdAsync(Ulid requestId);
    ValueTask<Result<ContactGroup>> ChangeStatusContactGroupAsync(ChangeStatusContactGroupCommand request);
    ValueTask<Result<ContactGroup>> CreateContactGroupAsync(CreateContactGroupCommand request);
    ValueTask<Result<ContactGroup>> UpdateContactGroupAsync(UpdateContactGroupCommand request);
    ValueTask<Result<ContactGroup>> DeleteContactGroupAsync(Ulid id);
}
