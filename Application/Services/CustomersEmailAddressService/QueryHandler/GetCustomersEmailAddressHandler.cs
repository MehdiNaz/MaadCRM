namespace Application.Services.CustomersEmailAddressService.QueryHandler;

public readonly struct GetCustomersEmailAddressHandler : IRequestHandler<GetCustomersEmailAddressesByIdQuery, CustomersEmailAddress?>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public GetCustomersEmailAddressHandler(ICustomersEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersEmailAddress?> Handle(GetCustomersEmailAddressesByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetEmailAddressByIdAsync(request.EmailAddressId);
}