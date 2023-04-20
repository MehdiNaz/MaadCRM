namespace Application.Services.ContactService.CommandHandlers;

public readonly struct CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Contact>
{
    private readonly IContactRepository _repository;

    public CreateContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        CreateContactCommand item = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailId = request.EmailId,
            ContactGroupId = request.ContactGroupId,
            Job = request.Job,
            BusinessId = request.BusinessId
        };
        return await _repository.CreateContactAsync(item);
    }
}
