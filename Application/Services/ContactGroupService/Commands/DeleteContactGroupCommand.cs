﻿namespace Application.Services.ContactGroupService.Commands;

public struct DeleteContactGroupCommand : IRequest<ContactGroup>
{
    public Ulid ContactGroupId { get; set; }
}