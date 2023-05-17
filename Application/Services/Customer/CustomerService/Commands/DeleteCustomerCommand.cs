namespace Application.Services.Customer.CustomerService.Commands;

public struct DeleteCustomerCommand : IRequest<Result<CustomerResponse>>
{
    public Ulid CustomerId { get; set; }
    public string UserId { get; set; }
}