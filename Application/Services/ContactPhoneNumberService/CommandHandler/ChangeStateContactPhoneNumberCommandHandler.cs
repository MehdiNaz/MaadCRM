namespace Application.Services.ContactPhoneNumberService.CommandHandler;

public readonly struct ChangeStateContactPhoneNumberCommandHandler : IRequestHandler<ChangeStateContactPhoneNumberCommand, ContactPhoneNumber?>
{
    private readonly IContactPhoneNumberRepository _repository;

    public ChangeStateContactPhoneNumberCommandHandler(IContactPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactPhoneNumber?> Handle(ChangeStateContactPhoneNumberCommand request,
        CancellationToken cancellationToken)
        => await _repository.ChangeStatusContactPhoneNumberByIdAsync(request.ContactPhoneNumberStatus, request.ContactPhoneNumberId);
}