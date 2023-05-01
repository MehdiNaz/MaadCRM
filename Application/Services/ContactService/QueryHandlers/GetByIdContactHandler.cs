namespace Application.Services.ContactService.QueryHandlers;

public readonly struct GetByIdContactHandler : IRequestHandler<ContactByIdQuery, Result<Contact>>
{
    private readonly IContactRepository _repository;

    public GetByIdContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Contact>> Handle(ContactByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetContactByIdAsync(request.ContactId)).Match(result => new Result<Contact>(result), exception => new Result<Contact>(exception));
        }
        catch (Exception e)
        {
            return new Result<Contact>(new Exception(e.Message));
        }
    }
}