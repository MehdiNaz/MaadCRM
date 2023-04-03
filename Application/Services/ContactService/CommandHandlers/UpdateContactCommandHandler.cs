namespace Application.Services.ContactService.CommandHandlers;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Contact>
{
    private readonly IContactRepository _repository;

    public UpdateContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
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
        await _repository.UpdateContactAsync(item, request.ContactId);
        return item;
    }
}
