namespace Application.Services.Customer.CustomerService.QueryHandler;

public readonly struct CustomerByFilterItemsHandler : IRequestHandler<CustomerByFilterItemsQuery, Result<CustomerDashboardResponse>>
{
    private readonly ICustomerRepository _repository;

    public CustomerByFilterItemsHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerDashboardResponse>> Handle(CustomerByFilterItemsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.FilterByItemsAsync(request))
                .Match(result => new Result<CustomerDashboardResponse>(result),
                exception => new Result<CustomerDashboardResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerDashboardResponse>(new Exception(e.Message));
        }
    }
}