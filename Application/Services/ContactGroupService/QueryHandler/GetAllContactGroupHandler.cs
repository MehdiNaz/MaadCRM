namespace Application.Services.ContactGroupService.QueryHandler;

public readonly struct GetAllContactGroupHandler : IRequestHandler<AllContactGroupsQuery, Result<ICollection<ContactGroup>>>
{
    private readonly IContactGroupRepository _repository;

    public GetAllContactGroupHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ContactGroup>>> Handle(AllContactGroupsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllContactGroupsAsync(request)).Match(result => new Result<ICollection<ContactGroup>>(result), exception => new Result<ICollection<ContactGroup>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactGroup>>(new Exception(e.Message));
        }
    }
}