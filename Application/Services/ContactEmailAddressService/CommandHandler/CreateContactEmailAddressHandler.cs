namespace Application.Services.ContactEmailAddressService.CommandHandler;

public class CreateContactEmailAddressHandler : IRequestHandler<CreateContactEmailAddressCommand, ContactsEmailAddress>
{
    private readonly IContactsEmailAddressRepository _repository;

    public CreateContactEmailAddressHandler(IContactsEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactsEmailAddress> Handle(CreateContactEmailAddressCommand request, CancellationToken cancellationToken)
    {
        ContactsEmailAddress item = new()
        {
            CustomersEmailAddrs = request.CustomersEmailAddrs
        };
        await _repository.CreateContactsEmailAddressAsync(item);
        return item;
    }
}