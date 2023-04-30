namespace Application.Services.CustomerService.QueryHandler;

public readonly struct BelghovehCustomersCountHandler : IRequestHandler<BelghovehCustomersCountQuery, Result<int>>
{
    private readonly ICustomerRepository _repository;

    public BelghovehCustomersCountHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(BelghovehCustomersCountQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ShowBelghovehCustomersCountAsync())
                .Match(result => new Result<int>(result),
                    exception => new Result<int>(exception));
        }
        catch (Exception e)
        {
            return new Result<int>(new Exception(e.Message));
        }
    }
}
