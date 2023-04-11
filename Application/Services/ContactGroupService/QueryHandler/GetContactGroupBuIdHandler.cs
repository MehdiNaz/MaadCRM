namespace Application.Services.ContactGroupService.QueryHandler;

public readonly struct GetContactGroupBuIdHandler : IRequestHandler<GetContactGroupByIdQuery, ContactGroup?>
{
    private readonly IContactGroupRepository _repository;

    public GetContactGroupBuIdHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactGroup?> Handle(GetContactGroupByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetContactGroupByIdAsync(request.ContactGroupId);
}