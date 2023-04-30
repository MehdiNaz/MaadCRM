namespace Application.Services.CustomerService.QueryHandler;

public readonly struct NaRazyCustomersCountHandler : IRequestHandler<NaRazyCustomersCountQuery, Result<int>>
{
    private readonly ICustomerRepository _repository;

    public NaRazyCustomersCountHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(NaRazyCustomersCountQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ShowNaRazyCustomersCountAsync())
                .Match(result => new Result<int>(result),
                    exception => new Result<int>(exception));
        }
        catch (Exception e)
        {
            return new Result<int>(new Exception(e.Message));
        }
    }
}
