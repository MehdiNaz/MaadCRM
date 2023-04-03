namespace Application.Services.CustomersAddressService.QueryHandler;

public class GetCustomersAddressByIdHandler : IRequestHandler<GetCustomerAddressByIdQuery, CustomersAddress?>
{
    private readonly ICustomersAddressRepository _repository;

    public GetCustomersAddressByIdHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersAddress?> Handle(GetCustomerAddressByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetAddressByIdAsync(request.CustomersAddressId);
}