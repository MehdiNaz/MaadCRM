namespace Application.Services.CustomerService.QueryHandler;

public readonly struct BelFelCustomersCountHandler : IRequestHandler<BelFelCustomersCountQuery, Result<int>>
{
    private readonly ICustomerRepository _repository;

    public BelFelCustomersCountHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(BelFelCustomersCountQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ShowBelFelCustomersCountAsync())
                .Match(result => new Result<int>(result),
                    exception => new Result<int>(exception));
        }
        catch (Exception e)
        {
            return new Result<int>(new Exception(e.Message));
        }
    }
}
