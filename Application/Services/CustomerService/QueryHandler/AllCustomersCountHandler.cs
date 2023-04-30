namespace Application.Services.CustomerService.QueryHandler;

public readonly struct AllCustomersCountHandler : IRequestHandler<AllCustomersCountQuery, Result<int>>
{
    private readonly ICustomerRepository _repository;

    public AllCustomersCountHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(AllCustomersCountQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ShowAllCustomersCountAsync())
                .Match(result => new Result<int>(result),
                    exception => new Result<int>(exception));
        }
        catch (Exception e)
        {
            return new Result<int>(new Exception(e.Message));
        }
    }
}
