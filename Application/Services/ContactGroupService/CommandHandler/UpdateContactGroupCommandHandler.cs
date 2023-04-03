namespace Application.Services.ContactGroupService.CommandHandler;

public class UpdateContactGroupCommandHandler : IRequestHandler<UpdateContactGroupCommand, ContactGroup>
{
    private readonly IContactGroupRepository _repository;

    public UpdateContactGroupCommandHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactGroup> Handle(UpdateContactGroupCommand request, CancellationToken cancellationToken)
    {
        ContactGroup item = new()
        {
            GroupName = request.ContactGroupName,
            DisplayOrder = request.DisplayOrder
        };
        await _repository.UpdateContactGroupAsync(item, request.ContactGroupId);
        return item;
    }
}