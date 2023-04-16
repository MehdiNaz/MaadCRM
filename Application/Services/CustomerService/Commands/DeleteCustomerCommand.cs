namespace Application.Services.CustomerService.Commands;

public struct DeleteCustomerCommand : IRequest<CustomerResponse?>
{
    public Ulid CustomerId { get; set; }
}