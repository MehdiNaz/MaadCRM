namespace Application.Services.ContactGroupService.QueryHandler;

public readonly struct GetContactGroupBuIdHandler : IRequestHandler<ContactGroupByIdQuery, Result<ContactGroup>>
{
    private readonly IContactGroupRepository _repository;

    public GetContactGroupBuIdHandler(IContactGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactGroup>> Handle(ContactGroupByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetContactGroupByIdAsync(request.ContactGroupId)).Match(result => new Result<ContactGroup>(result), exception => new Result<ContactGroup>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactGroup>(new Exception(e.Message));
        }
    }
}