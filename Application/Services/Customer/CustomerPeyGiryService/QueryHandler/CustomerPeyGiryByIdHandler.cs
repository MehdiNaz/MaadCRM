namespace Application.Services.Customer.CustomerPeyGiryService.QueryHandler;

public readonly struct CustomerPeyGiryByIdHandler : IRequestHandler<CustomerPeyGiryByIdQuery, Result<CustomerPeyGiryResponse>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public CustomerPeyGiryByIdHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerPeyGiryResponse>> Handle(CustomerPeyGiryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerPeyGiryByIdAsync(request.CustomerPeyGiryId))
                .Match(result => new Result<CustomerPeyGiryResponse>(result),
                    exception => new Result<CustomerPeyGiryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiryResponse>(new Exception(e.Message));
        }
    }
}