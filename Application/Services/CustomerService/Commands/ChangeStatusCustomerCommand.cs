namespace Application.Services.CustomerService.Commands;

public struct ChangeStatusCustomerCommand : IRequest<Result<CustomerResponse>>
{
    public Ulid CustomerId { get; set; }
    public Status CustomerStatus { get; set; }
}