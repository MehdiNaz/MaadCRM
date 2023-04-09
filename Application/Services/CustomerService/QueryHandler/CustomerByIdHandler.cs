namespace Application.Services.CustomerService.QueryHandler;

public readonly struct CustomerByIdHandler : IRequestHandler<CustomerByIdQuery, Customer?>
{
    private readonly ICustomerRepository _repository;

    public CustomerByIdHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetCustomerByIdAsync(request.CustomerId);
}