namespace Application.Services.CustomerService.QueryHandler;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, ICollection<Customer?>>
{
    private readonly ICustomerRepository _repository;

    public GetAllCustomersHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Customer?>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllCustomersAsync();
}