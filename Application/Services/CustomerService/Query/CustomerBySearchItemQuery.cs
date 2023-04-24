namespace Application.Services.CustomerService.Query;

public struct CustomerBySearchItemQuery : IRequest<Result<ICollection<CustomerResponse>>>
{
    public string Q { get; set; }
}
