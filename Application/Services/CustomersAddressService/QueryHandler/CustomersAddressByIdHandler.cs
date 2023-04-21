namespace Application.Services.CustomersAddressService.QueryHandler;

public readonly struct CustomersAddressByIdHandler : IRequestHandler<CustomerAddressByIdQuery, CustomerAddress?>
{
    private readonly ICustomersAddressRepository _repository;

    public CustomersAddressByIdHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerAddress?> Handle(CustomerAddressByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetAddressByIdAsync(request.CustomersAddressId);
}