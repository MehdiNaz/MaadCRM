namespace Application.Services.CustomerService.Query;

public struct CustomerBySearchItemQuery : IRequest<Result<CustomerDashboardResponse>>
{
    public string Q { get; set; }
}
