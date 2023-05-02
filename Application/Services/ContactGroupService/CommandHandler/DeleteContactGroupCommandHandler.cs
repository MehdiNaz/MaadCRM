namespace Application.Services.ContactGroupService.CommandHandler;

public readonly struct DeleteContactGroupCommandHandler : IRequestHandler<DeleteContactGroupCommand, Result<ContactGroup>>
{
    private readonly IContactGroupRepository _repository;

    public DeleteContactGroupCommandHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactGroup>> Handle(DeleteContactGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteContactGroupAsync(request.Id)).Match(result => new Result<ContactGroup>(result), exception => new Result<ContactGroup>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new Exception(e.Message));
        }
    }
}