namespace Application.Services.CustomerService.QueryHandler;

public readonly struct AllCustomersHandler : IRequestHandler<AllCustomersQuery, ICollection<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public AllCustomersHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerResponse>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllCustomersAsync(request.UserId);
}