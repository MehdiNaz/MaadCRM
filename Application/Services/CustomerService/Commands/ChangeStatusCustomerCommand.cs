namespace Application.Services.CustomerService.Commands;

public struct ChangeStatusCustomerCommand : IRequest<Customer?>
{
    public Ulid CustomerId { get; set; }
    public Status CustomerStatus { get; set; }
}