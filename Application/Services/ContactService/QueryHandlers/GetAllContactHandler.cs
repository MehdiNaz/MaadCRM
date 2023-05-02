namespace Application.Services.ContactService.QueryHandlers;

public readonly struct GetAllContactHandler : IRequestHandler<AllContactQuery, Result<ICollection<ContactsResponse>>>
{
    private readonly IContactRepository _repository;

    public GetAllContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ContactsResponse>>> Handle(AllContactQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllContactAsync()).Match(result => new Result<ICollection<ContactsResponse>>(result), exception => new Result<ICollection<ContactsResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactsResponse>>(new Exception(e.Message));
        }
    }
}