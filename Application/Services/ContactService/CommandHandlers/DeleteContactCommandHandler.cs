namespace Application.Services.ContactService.CommandHandlers;

public readonly struct DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Result<Contact>>
{
    private readonly IContactRepository _repository;

    public DeleteContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Contact>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteContactAsync(request.ContactId)).Match(result => new Result<Contact>(result), exception => new Result<Contact>(exception));
        }
        catch (Exception e)
        {
            return new Result<Contact>(new Exception(e.Message));
        }
    }
}