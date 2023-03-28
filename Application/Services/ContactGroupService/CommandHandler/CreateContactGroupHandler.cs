namespace Application.Services.ContactGroupService.CommandHandler;

public class CreateContactGroupHandler : IRequestHandler<CreateContactGroupCommand, ContactGroup>
{
    private readonly IContactGroupRepository _repository;

    public CreateContactGroupHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactGroup> Handle(CreateContactGroupCommand request, CancellationToken cancellationToken)
    {
        ContactGroup item = new()
        {
            GroupName = request.GroupName,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.CreateContactGroupAsync(item);
        return item;
    }
}