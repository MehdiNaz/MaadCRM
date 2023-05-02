namespace Application.Services.ContactGroupService.CommandHandler;

public readonly struct ChangeStateContactGroupCommandHandler : IRequestHandler<ChangeStatusContactGroupCommand, Result<ContactGroup>>
{
    private readonly IContactGroupRepository _repository;

    public ChangeStateContactGroupCommandHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactGroup>> Handle(ChangeStatusContactGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusContactGroupAsync(request)).Match(result => new Result<ContactGroup>(result), exception => new Result<ContactGroup>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new Exception(e.Message));
        }
    }
}