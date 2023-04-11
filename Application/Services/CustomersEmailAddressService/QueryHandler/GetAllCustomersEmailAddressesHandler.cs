namespace Application.Services.CustomersEmailAddressService.QueryHandler;

public readonly struct GetAllCustomersEmailAddressesHandler : IRequestHandler<GetAllCustomersEmailAddressesQuery, ICollection<CustomersEmailAddress?>>
{
    private readonly ICustomersEmailAddressRepository _repository;

    public GetAllCustomersEmailAddressesHandler(ICustomersEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomersEmailAddress?>> Handle(GetAllCustomersEmailAddressesQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllEmailAddressesAsync();
}