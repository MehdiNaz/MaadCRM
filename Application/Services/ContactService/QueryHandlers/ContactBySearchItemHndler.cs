namespace Application.Services.ContactService.QueryHandlers;

public readonly struct ContactBySearchItemHndler : IRequestHandler<ContactBySearchItemQuery, Result<ICollection<ContactsResponse>>>
{
    private readonly IContactRepository _repository;

    public ContactBySearchItemHndler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ContactsResponse>>> Handle(ContactBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchContactAsync(request.Q)).Match(result => new Result<ICollection<ContactsResponse>>(result), exception => new Result<ICollection<ContactsResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactsResponse>>(new Exception(e.Message));
        }
    }
}
