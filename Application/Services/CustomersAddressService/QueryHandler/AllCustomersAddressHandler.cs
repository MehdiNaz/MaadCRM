namespace Application.Services.CustomersAddressService.QueryHandler;

public class AllCustomersAddressHandler: IRequestHandler<AllCustomerAddressQuery, ICollection<CustomersAddress?>>
{
    private readonly ICustomersAddressRepository _repository;

    public AllCustomersAddressHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomersAddress?>> Handle(AllCustomerAddressQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllAddressesAsync();
}