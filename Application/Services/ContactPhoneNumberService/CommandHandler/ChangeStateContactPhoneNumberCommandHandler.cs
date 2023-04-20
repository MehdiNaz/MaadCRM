namespace Application.Services.ContactPhoneNumberService.CommandHandler;

public readonly struct ChangeStateContactPhoneNumberCommandHandler : IRequestHandler<ChangeStatusContactPhoneNumberCommand, ContactPhoneNumber?>
{
    private readonly IContactPhoneNumberRepository _repository;

    public ChangeStateContactPhoneNumberCommandHandler(IContactPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactPhoneNumber?> Handle(ChangeStatusContactPhoneNumberCommand request,
        CancellationToken cancellationToken)
        => await _repository.ChangeStatusContactPhoneNumberByIdAsync(request);
}