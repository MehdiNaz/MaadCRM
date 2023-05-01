namespace Application.Services.ContactService.CommandHandlers;

public readonly struct UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Result<Contact>>
{
    private readonly IContactRepository _repository;

    public UpdateContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Contact>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        try
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
            return (await _repository.UpdateContactAsync(item)).Match(result => new Result<Contact>(result), exception => new Result<Contact>(exception));
        }
        catch (Exception e)
        {
            return new Result<Contact>(new Exception(e.Message));
        }
    }
}
