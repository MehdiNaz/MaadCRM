namespace Application.Services.ContactGroupService.CommandHandler;

public readonly struct ChangeStateContactGroupCommandHandler : IRequestHandler<ChangeStateContactGroupCommand, ContactGroup?>
{
    private readonly IContactGroupRepository _repository;

    public ChangeStateContactGroupCommandHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactGroup?> Handle(ChangeStateContactGroupCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStateContactGroupAsync(request.ContactGroupStatus, request.ContactGroupId);
}