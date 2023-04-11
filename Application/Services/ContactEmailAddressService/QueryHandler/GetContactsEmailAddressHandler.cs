namespace Application.Services.ContactEmailAddressService.QueryHandler;

public readonly struct GetContactsEmailAddressHandler : IRequestHandler<GetContactsEmailAddressByIdQuery, ContactsEmailAddress>
{
    private readonly IContactsEmailAddressRepository _repository;

    public GetContactsEmailAddressHandler(IContactsEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactsEmailAddress> Handle(GetContactsEmailAddressByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetContactsEmailAddressByIdAsync(request.ContactsEmailAddressId))!;
}