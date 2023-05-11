namespace Application.Services.Customer.CustomerPeyGiryService.QueryHandler;

public readonly struct AllCustomerPeyGiryHandler : IRequestHandler<AllCustomerPeyGiriesQuery, Result<ICollection<CustomerPeyGiryResponse>>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public AllCustomerPeyGiryHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerPeyGiryResponse>>> Handle(AllCustomerPeyGiriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerPeyGiriesAsync(request.CustomerId)).Match(result => new Result<ICollection<CustomerPeyGiryResponse>>(result), exception => new Result<ICollection<CustomerPeyGiryResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerPeyGiryResponse>>(new Exception(e.Message));
        }
    }
}