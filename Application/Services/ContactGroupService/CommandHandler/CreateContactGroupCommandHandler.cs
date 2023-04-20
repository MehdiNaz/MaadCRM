﻿namespace Application.Services.ContactGroupService.CommandHandler;

public readonly struct CreateContactGroupCommandHandler : IRequestHandler<CreateContactGroupCommand, ContactGroup>
{
    private readonly IContactGroupRepository _repository;

    public CreateContactGroupCommandHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactGroup> Handle(CreateContactGroupCommand request, CancellationToken cancellationToken)
    {
        CreateContactGroupCommand item = new()
        {
            GroupName = request.GroupName,
            DisplayOrder = request.DisplayOrder
        };

        return await _repository.CreateContactGroupAsync(item);
    }
}