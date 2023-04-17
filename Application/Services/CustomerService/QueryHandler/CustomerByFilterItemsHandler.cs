namespace Application.Services.CustomerService.QueryHandler;

public readonly struct CustomerByFilterItemsHandler : IRequestHandler<CustomerByFilterItemsQuery, ICollection<CustomerResponse>?>
{
    private readonly ICustomerRepository _repository;

    public CustomerByFilterItemsHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerResponse>> Handle(CustomerByFilterItemsQuery request, CancellationToken cancellationToken)
        => await _repository.SearchByItemsAsync(request);
}