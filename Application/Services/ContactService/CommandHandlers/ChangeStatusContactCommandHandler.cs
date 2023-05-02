namespace Application.Services.ContactService.CommandHandlers;

public readonly struct ChangeStatusContactCommandHandler : IRequestHandler<ChangeStatusContactCommand, Result<ContactsResponse>>
{
    private readonly IContactRepository _repository;

    public ChangeStatusContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactsResponse>> Handle(ChangeStatusContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusContactByIdAsync(request)).Match(result => new Result<ContactsResponse>(result),
                exception => new Result<ContactsResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ContactsResponse>(new Exception(e.Message));
        }
    }
}