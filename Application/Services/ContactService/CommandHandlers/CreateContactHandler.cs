namespace Application.Services.ContactService.CommandHandlers;

public class CreateContactHandler : IRequestHandler<CreateContactCommand, Contact>
{
    private readonly IContactRepository _repository;

    public CreateContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        Contact item = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailId = request.EmailId,
            ContactGroupId = request.ContactGroupId,
            Job = request.Job,
            BusinessId = request.BusinessId
        };
        await _repository.CreateContactAsync(item);
        return item;
    }
}
