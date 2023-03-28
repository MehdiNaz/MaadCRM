namespace Application.Services.ContactGroupService.CommandHandler;

public class UpdateContactGroupHandler : IRequestHandler<UpdateContactGroupCommand, ContactGroup>
{
    private readonly IContactGroupRepository _repository;

    public UpdateContactGroupHandler(IContactGroupRepository repository)
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