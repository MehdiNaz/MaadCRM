namespace Application.Services.ContactService.CommandHandlers;

public readonly struct CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Result<Contact>>
{
    private readonly IContactRepository _repository;

    public CreateContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Contact>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        try
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
            return (await _repository.CreateContactAsync(item)).Match(result => new Result<Contact>(result), exception => new Result<Contact>(exception));
        }
        catch (Exception e)
        {
            return new Result<Contact>(new Exception(e.Message));
        }
    }
}
