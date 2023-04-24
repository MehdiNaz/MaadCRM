namespace Application.Services.CustomerService.QueryHandler;

public readonly struct CustomerBySearchItemHandler : IRequestHandler<CustomerBySearchItemQuery, Result<ICollection<CustomerResponse>>>
{
    private readonly ICustomerRepository _repository;

    public CustomerBySearchItemHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerResponse>>> Handle(CustomerBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchByItemsAsync(request.Q)).Match(result => new Result<ICollection<CustomerResponse>>(result), exception => new Result<ICollection<CustomerResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerResponse>>(new Exception(e.Message));
        }
    }
}