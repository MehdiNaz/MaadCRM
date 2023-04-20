namespace Application.Services.ContactService.CommandHandlers;

public readonly struct ChangeStatusContactCommandHandler : IRequestHandler<ChangeStatusContactCommand, Contact?>
{
    private readonly IContactRepository _repository;

    public ChangeStatusContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact?> Handle(ChangeStatusContactCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusContactByIdAsync(request);
}