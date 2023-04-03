namespace Application.Services.CustomersAddressService.QueryHandler;

public class GetAllCustomersAddressHandler: IRequestHandler<GetAllCustomerAddressQuery, ICollection<CustomersAddress?>>
{
    private readonly ICustomersAddressRepository _repository;

    public GetAllCustomersAddressHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomersAddress?>> Handle(GetAllCustomerAddressQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllAddressesAsync();
}