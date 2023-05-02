namespace Application.Services.ContactGroupService.CommandHandler;

public readonly struct CreateContactGroupCommandHandler : IRequestHandler<CreateContactGroupCommand, Result<ContactGroup>>
{
    private readonly IContactGroupRepository _repository;

    public CreateContactGroupCommandHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactGroup>> Handle(CreateContactGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateContactGroupCommand item = new()
            {
                GroupName = request.GroupName,
                DisplayOrder = request.DisplayOrder
            };
            return (await _repository.CreateContactGroupAsync(item)).Match(result => new Result<ContactGroup>(result), exception => new Result<ContactGroup>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new Exception(e.Message));
        }
    }
}