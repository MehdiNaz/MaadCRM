namespace Application.Services.CustomerService.QueryHandler;

public readonly struct CustomerByFilterItemsHandler : IRequestHandler<CustomerByFilterItemsQuery, Result<ICollection<CustomerResponse>>>
{
    private readonly ICustomerRepository _repository;

    public CustomerByFilterItemsHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerResponse>>> Handle(CustomerByFilterItemsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.FilterByItemsAsync(request)).Match(result => new Result<ICollection<CustomerResponse>>(result), exception => new Result<ICollection<CustomerResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerResponse>>(new Exception(e.Message));
        }
    }
}