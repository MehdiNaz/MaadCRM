namespace Application.Services.ContactService.CommandHandlers;

public readonly struct UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Contact>
{
    private readonly IContactRepository _repository;

    public UpdateContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        UpdateContactCommand item = new()
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailId = request.EmailId,
            ContactGroupId = request.ContactGroupId,
            Job = request.Job,
            BusinessId = request.BusinessId
        };
        return await _repository.UpdateContactAsync(item);
    }
}
