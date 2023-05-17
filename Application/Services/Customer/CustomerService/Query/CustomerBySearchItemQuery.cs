namespace Application.Services.Customer.CustomerService.Query;

public struct CustomerBySearchItemQuery : IRequest<Result<CustomerDashboardResponse>>
{
    public string Q { get; set; }
    public string UserId { get; set; }
}
