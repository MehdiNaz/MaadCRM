namespace Application.Services.ContactEmailAddressService.QueryHandler;

public readonly struct GetAllContactsEmailAddressHandler : IRequestHandler<GetAllContactsEmailAddressQuery, ICollection<ContactsEmailAddress?>>
{
    private readonly IContactsEmailAddressRepository _repository;

    public GetAllContactsEmailAddressHandler(IContactsEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ContactsEmailAddress?>> Handle(GetAllContactsEmailAddressQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllContactsEmailAddressAsync();
}