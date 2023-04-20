namespace Application.Services.ContactEmailAddressService.CommandHandler;

public readonly struct ChangeStatusContactEmailAddressCommandHandler:IRequestHandler<ChangeStatusContactEmailAddressCommand , ContactsEmailAddress?>
{
    readonly IContactsEmailAddressRepository _repository;

    public ChangeStatusContactEmailAddressCommandHandler(IContactsEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactsEmailAddress?> Handle(ChangeStatusContactEmailAddressCommand request,
        CancellationToken cancellationToken)
        => await _repository.ChangeStatusContactsEmailAddressByIdAsync(request);
}