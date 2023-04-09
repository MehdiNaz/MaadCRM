namespace Application.Services.CustomerService.QueryHandler;

public class AllCustomersHandler : IRequestHandler<AllCustomersQuery, ICollection<Customer?>>
{
    private readonly ICustomerRepository _repository;

    public AllCustomersHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Customer?>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllCustomersAsync();
}