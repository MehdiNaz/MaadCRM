namespace Application.Services.CustomersAddressService.QueryHandler;

public class CustomersAddressByIdHandler : IRequestHandler<CustomerAddressByIdQuery, CustomersAddress?>
{
    private readonly ICustomersAddressRepository _repository;

    public CustomersAddressByIdHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersAddress?> Handle(CustomerAddressByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetAddressByIdAsync(request.CustomersAddressId);
}