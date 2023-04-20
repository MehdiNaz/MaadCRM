namespace Application.Services.ContactGroupService.CommandHandler;

public readonly struct UpdateContactGroupCommandHandler : IRequestHandler<UpdateContactGroupCommand, ContactGroup>
{
    private readonly IContactGroupRepository _repository;

    public UpdateContactGroupCommandHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactGroup> Handle(UpdateContactGroupCommand request, CancellationToken cancellationToken)
    {
        UpdateContactGroupCommand item = new()
        {
            Id = request.Id,
            GroupName = request.GroupName,
            DisplayOrder = request.DisplayOrder
        };
        return await _repository.UpdateContactGroupAsync(item);
    }
}