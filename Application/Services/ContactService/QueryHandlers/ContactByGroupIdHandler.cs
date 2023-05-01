namespace Application.Services.ContactService.QueryHandlers;

public readonly struct ContactByGroupIdHandler : IRequestHandler<ContactByGroupIdQuery, Result<ICollection<ContactsResponse>>>
{
    readonly IContactRepository _repository;

    public ContactByGroupIdHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ContactsResponse>>> Handle(ContactByGroupIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetContactByGroupIdAsync(request.ContactGroupId)).Match(result => new Result<ICollection<ContactsResponse>>(result), exception => new Result<ICollection<ContactsResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ContactsResponse>>(new Exception(e.Message));
        }
    }
}
