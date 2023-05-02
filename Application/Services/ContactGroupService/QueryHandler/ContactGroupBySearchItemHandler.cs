namespace Application.Services.ContactGroupService.QueryHandler;

public readonly struct ContactGroupBySearchItemHandler : IRequestHandler<ContactGroupBySearchItemQuery, Result<ICollection<ContactGroup>>>
{
    private readonly IContactGroupRepository _repository;

    public ContactGroupBySearchItemHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ContactGroup>>> Handle(ContactGroupBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchContactGroupAsync(request.Q)).Match(result => new Result<ICollection<ContactGroup>>(result), exception => new Result<ICollection<ContactGroup>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactGroup>>(new Exception(e.Message));
        }
    }
}
