namespace Application.Services.ContactService.QueryHandlers;

public readonly struct GetAllContactHandler : IRequestHandler<AllContactQuery, Result<ICollection<Contact>>>
{
    private readonly IContactRepository _repository;

    public GetAllContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<Contact>>> Handle(AllContactQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllContactAsync()).Match(result => new Result<ICollection<Contact>>(result), exception => new Result<ICollection<Contact>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<Contact>>(new Exception(e.Message));
        }
    }
}