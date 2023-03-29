namespace Application.Services.ContactService.QueryHandlers;

public class GetByIdContactHandler : IRequestHandler<GetByIdContactQuery, Contact?>
{
    private readonly IContactRepository _repository;

    public GetByIdContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact?> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
        => await _repository.GetContactByIdAsync(request.ContactId);
}