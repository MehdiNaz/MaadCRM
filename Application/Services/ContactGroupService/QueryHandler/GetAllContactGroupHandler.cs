namespace Application.Services.ContactGroupService.QueryHandler;

public readonly struct GetAllContactGroupHandler : IRequestHandler<GetAllContactGroupQuery, ICollection<ContactGroup?>>
{
    private readonly IContactGroupRepository _repository;

    public GetAllContactGroupHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ContactGroup?>> Handle(GetAllContactGroupQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllContactGroupsAsync();
}