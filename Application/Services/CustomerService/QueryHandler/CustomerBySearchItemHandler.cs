namespace Application.Services.CustomerService.QueryHandler;

public readonly struct CustomerBySearchItemHandler : IRequestHandler<CustomerBySearchItemQuery, Result<CustomerDashboardResponse>>
{
    private readonly ICustomerRepository _repository;

    public CustomerBySearchItemHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerDashboardResponse>> Handle(CustomerBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchByItemsAsync(request.Q, request.UserId)).Match(result => new Result<CustomerDashboardResponse>(result), exception => new Result<CustomerDashboardResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerDashboardResponse>(new Exception(e.Message));
        }
    }
}