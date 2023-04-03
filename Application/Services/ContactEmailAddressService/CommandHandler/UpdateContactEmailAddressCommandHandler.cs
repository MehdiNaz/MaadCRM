namespace Application.Services.ContactEmailAddressService.CommandHandler;

public class UpdateContactEmailAddressCommandHandler : IRequestHandler<UpdateContactEmailAddressCommand, ContactsEmailAddress>
{
    private readonly IContactsEmailAddressRepository _repository;

    public UpdateContactEmailAddressCommandHandler(IContactsEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactsEmailAddress> Handle(UpdateContactEmailAddressCommand request, CancellationToken cancellationToken)
    {
        ContactsEmailAddress item = new()
        {
            CustomersEmailAddrs = request.CustomersEmailAddrs
        };
        await _repository.UpdateContactsEmailAddressAsync(item, request.CustomersEmailAddressId);
        return item;
    }
}