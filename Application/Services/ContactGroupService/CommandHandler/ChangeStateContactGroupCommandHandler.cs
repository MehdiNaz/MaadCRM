namespace Application.Services.ContactGroupService.CommandHandler;

public readonly struct ChangeStateContactGroupCommandHandler : IRequestHandler<ChangeStatusContactGroupCommand, ContactGroup?>
{
    private readonly IContactGroupRepository _repository;

    public ChangeStateContactGroupCommandHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactGroup?> Handle(ChangeStatusContactGroupCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusContactGroupAsync(request);
}