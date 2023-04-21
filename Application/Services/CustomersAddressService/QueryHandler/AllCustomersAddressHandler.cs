namespace Application.Services.CustomersAddressService.QueryHandler;

public readonly struct AllCustomersAddressHandler: IRequestHandler<AllCustomerAddressQuery, ICollection<CustomerAddress?>>
{
    private readonly ICustomersAddressRepository _repository;

    public AllCustomersAddressHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerAddress?>> Handle(AllCustomerAddressQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllAddressesAsync(request.CustomerId);
}