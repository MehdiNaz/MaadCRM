namespace Application.Services.CustomerService.QueryHandler;

public readonly struct CustomerByIdHandler : IRequestHandler<CustomerByIdQuery, CustomerResponse>
{
    private readonly ICustomerRepository _repository;

    public CustomerByIdHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerResponse> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetCustomerByIdAsync(request.CustomerId);
}