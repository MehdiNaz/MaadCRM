namespace Application.Services.ContactEmailAddressService.CommandHandler;

public readonly struct CreateContactEmailAddressCommandHandler : IRequestHandler<CreateContactEmailAddressCommand, ContactsEmailAddress>
{
    private readonly IContactsEmailAddressRepository _repository;

    public CreateContactEmailAddressCommandHandler(IContactsEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactsEmailAddress> Handle(CreateContactEmailAddressCommand request, CancellationToken cancellationToken)
    {
        CreateContactEmailAddressCommand item = new()
        {
            EmailAddress = request.EmailAddress
        };
        return await _repository.CreateContactsEmailAddressAsync(item);
    }
}