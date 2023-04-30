namespace Application.Services.CustomerService.QueryHandler;

public readonly struct DarHalePeyGiryCustomersCountHandler : IRequestHandler<DarHalePeyGiryCustomersCountQuery, Result<int>>
{
    private readonly ICustomerRepository _repository;

    public DarHalePeyGiryCustomersCountHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(DarHalePeyGiryCustomersCountQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ShowDarHalePeyGiryCustomersCountAsync())
                .Match(result => new Result<int>(result),
                    exception => new Result<int>(exception));
        }
        catch (Exception e)
        {
            return new Result<int>(new Exception(e.Message));
        }
    }
}
