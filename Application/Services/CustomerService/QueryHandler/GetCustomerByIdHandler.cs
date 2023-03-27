namespace Application.Services.CustomerService.QueryHandler;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer?>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByIdHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetCustomerByIdAsync(request.CustomerId);
}