namespace Application.Services.CustomerService.Commands;

public struct ChangeStatusCustomerCommand : IRequest<CustomerResponse?>
{
    public Ulid CustomerId { get; set; }
    public Status CustomerStatus { get; set; }
}