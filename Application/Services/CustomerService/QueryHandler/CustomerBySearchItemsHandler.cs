namespace Application.Services.CustomerService.QueryHandler;

public readonly struct CustomerBySearchItemsHandler : IRequestHandler<CustomerBySearchItemsQuery, ICollection<CustomerResponse>?>
{
    private readonly ICustomerRepository _repository;

    public CustomerBySearchItemsHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerResponse>> Handle(CustomerBySearchItemsQuery request, CancellationToken cancellationToken)
        => await _repository.SearchByItemsAsync(request);
}