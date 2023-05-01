namespace Application.Services.CustomerService.Query;

public struct CustomerDashBourdQuery : IRequest<Result<CustomerDashboardResponse>>
{
    public string UserId { get; set; }
}
