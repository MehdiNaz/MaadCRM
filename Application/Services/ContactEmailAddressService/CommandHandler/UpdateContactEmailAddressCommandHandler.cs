namespace Application.Services.ContactEmailAddressService.CommandHandler;

public readonly struct UpdateContactEmailAddressCommandHandler : IRequestHandler<UpdateContactEmailAddressCommand, ContactsEmailAddress>
{
    private readonly IContactsEmailAddressRepository _repository;

    public UpdateContactEmailAddressCommandHandler(IContactsEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactsEmailAddress> Handle(UpdateContactEmailAddressCommand request, CancellationToken cancellationToken)
    {
        UpdateContactEmailAddressCommand item = new()
        {
            Id = request.Id,
            EmailAddress = request.EmailAddress
        };
        return await _repository.UpdateContactsEmailAddressAsync(item);
    }
}