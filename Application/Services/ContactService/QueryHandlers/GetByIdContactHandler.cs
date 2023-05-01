namespace Application.Services.ContactService.QueryHandlers;

public readonly struct GetByIdContactHandler : IRequestHandler<ContactByIdQuery, Result<ContactsResponse>>
{
    private readonly IContactRepository _repository;

    public GetByIdContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactsResponse>> Handle(ContactByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetContactByIdAsync(request.ContactId)).Match(result => new Result<ContactsResponse>(result), exception => new Result<ContactsResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new Exception(e.Message));
        }
    }
}