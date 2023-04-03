﻿namespace Application.Services.ContactGroupService.Commands;

public struct CreateContactGroupCommand : IRequest<ContactGroup>
{
    public string GroupName { get; set; }
    public int DisplayOrder { get; set; }
}