namespace Application.Services.ContactService.CommandHandlers;

public readonly struct UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Result<ContactsResponse>>
{
    private readonly IContactRepository _repository;

    public UpdateContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactsResponse>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
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
            return (await _repository.UpdateContactAsync(item)).Match(result => new Result<ContactsResponse>(result), exception => new Result<ContactsResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new Exception(e.Message));
        }
    }
}
