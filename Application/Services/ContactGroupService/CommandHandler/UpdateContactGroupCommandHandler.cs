namespace Application.Services.ContactGroupService.CommandHandler;

public readonly struct UpdateContactGroupCommandHandler : IRequestHandler<UpdateContactGroupCommand, Result<ContactGroup>>
{
    private readonly IContactGroupRepository _repository;

    public UpdateContactGroupCommandHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactGroup>> Handle(UpdateContactGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateContactGroupCommand item = new()
            {
                Id = request.Id,
                GroupName = request.GroupName,
                DisplayOrder = request.DisplayOrder
            };
            return (await _repository.UpdateContactGroupAsync(item)).Match(result => new Result<ContactGroup>(result), exception => new Result<ContactGroup>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new Exception(e.Message));
        }
    }
}