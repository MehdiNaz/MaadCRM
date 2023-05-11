namespace Application.Services.Customer.CustomerPeyGiryService.QueryHandler;

public readonly struct CustomerPeyGiryByIdHandler : IRequestHandler<CustomerPeyGiryByIdQuery, Result<CustomerPeyGiry>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public CustomerPeyGiryByIdHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerPeyGiry>> Handle(CustomerPeyGiryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerPeyGiryByIdAsync(request.CustomerPeyGiryId)).Match(result => new Result<CustomerPeyGiry>(result), exception => new Result<CustomerPeyGiry>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new Exception(e.Message));
        }
    }
}