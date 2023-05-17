namespace Application.Services.Customer.CustomerService.Commands;

public struct ChangeStatusCustomerCommand : IRequest<Result<CustomerResponse>>
{
    public Ulid CustomerId { get; set; }
    public StatusType CustomerStatusType { get; set; }
}