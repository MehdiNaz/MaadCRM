namespace Application.Services.ContactService.CommandHandlers;

public readonly struct ChangeStatusContactCommandHandler : IRequestHandler<ChangeStatusContactCommand, Result<Contact>>
{
    private readonly IContactRepository _repository;

    public ChangeStatusContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Contact>> Handle(ChangeStatusContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusContactByIdAsync(request)).Match(result => new Result<Contact>(result), exception => new Result<Contact>(exception));
        }
        catch (Exception e)
        {
            return new Result<Contact>(new Exception(e.Message));
        }
    }
}