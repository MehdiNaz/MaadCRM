namespace Application.Services.Customer.CustomerService.QueryHandler;

public readonly struct CustomerDashBourdHandler : IRequestHandler<CustomerDashBourdQuery, Result<CustomerDashboardResponse>>
{
    readonly ICustomerRepository _repository;

    public CustomerDashBourdHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerDashboardResponse>> Handle(CustomerDashBourdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = new CustomerDashboardResponse();
            (await _repository.ShowBelghovehCustomersCountAsync()).Match(result => response.BelghovehCount = result, exception => response.BelghovehCount = 0);
            (await _repository.ShowBelFelCustomersCountAsync()).Match(result => response.BelFelCount = result, exception => response.BelFelCount = 0);
            (await _repository.ShowRazyCustomersCountAsync()).Match(result => response.RazyCount = result, exception => response.RazyCount = 0);
            (await _repository.ShowNaRazyCustomersCountAsync()).Match(result => response.NaRazyCount = result, exception => response.NaRazyCount = 0);
            (await _repository.ShowDarHalePeyGiryCustomersCountAsync()).Match(result => response.DarHalePeyGiryCount = result, exception => response.DarHalePeyGiryCount = 0);
            (await _repository.ShowVafadarCustomersCountAsync()).Match(result => response.VafadarCount = result, exception => response.VafadarCount = 0);
            (await _repository.ShowAllCustomersCountAsync()).Match(result => response.AllCount = result, exception => response.AllCount = 0);

            (await _repository.GetAllCustomersAsync(request.UserId)).Match(result => response.AllCustomersInfo = (List<CustomerResponse>)result, exception => response.AllCustomersInfo = null);

            return response;
        }
        catch (Exception e)
        {
            return new Result<CustomerDashboardResponse>(new Exception(e.Message));
        }
    }
}
