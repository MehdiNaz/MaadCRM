namespace Application.Services.ContactService.CommandHandlers;

public readonly struct CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Result<ContactsResponse>>
{
    private readonly IContactRepository _repository;

    public CreateContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactsResponse>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateContactCommand item = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddresses = request.EmailAddresses,
                PhoneNumber = request.PhoneNumber,
                ContactGroupId = request.ContactGroupId,
                Job = request.Job,
                IdUser = request.IdUser
            };
            return (await _repository.CreateContactAsync(item)).Match(result => new Result<ContactsResponse>(result), exception => new Result<ContactsResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new Exception(e.Message));
        }
    }
}
