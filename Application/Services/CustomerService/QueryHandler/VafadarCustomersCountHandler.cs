namespace Application.Services.CustomerService.QueryHandler;

public readonly struct VafadarCustomersCountHandler : IRequestHandler<VafadarCustomersCountQuery, Result<int>>
{
    private readonly ICustomerRepository _repository;

    public VafadarCustomersCountHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(VafadarCustomersCountQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ShowVafadarCustomersCountAsync())
                .Match(result => new Result<int>(result),
                    exception => new Result<int>(exception));
        }
        catch (Exception e)
        {
            return new Result<int>(new Exception(e.Message));
        }
    }
}
