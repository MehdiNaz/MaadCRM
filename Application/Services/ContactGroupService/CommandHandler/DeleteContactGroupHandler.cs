namespace Application.Services.ContactGroupService.CommandHandler;

public class DeleteContactGroupHandler : IRequestHandler<DeleteContactGroupCommand, ContactGroup>
{
    private readonly IContactGroupRepository _repository;

    public DeleteContactGroupHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactGroup> Handle(DeleteContactGroupCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteContactGroupAsync(request.ContactGroupId))!;
}