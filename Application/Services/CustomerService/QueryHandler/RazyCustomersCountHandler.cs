namespace Application.Services.CustomerService.QueryHandler;

public readonly struct RazyCustomersCountHandler : IRequestHandler<RazyCustomersCountQuery, Result<int>>
{
    private readonly ICustomerRepository _repository;

    public RazyCustomersCountHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(RazyCustomersCountQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ShowRazyCustomersCountAsync())
                .Match(result => new Result<int>(result),
                    exception => new Result<int>(exception));
        }
        catch (Exception e)
        {
            return new Result<int>(new Exception(e.Message));
        }
    }
}
