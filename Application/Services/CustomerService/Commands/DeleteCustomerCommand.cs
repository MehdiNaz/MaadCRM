namespace Application.Services.CustomerService.Commands;

public struct DeleteCustomerCommand : IRequest<Result<CustomerResponse>>
{
    public Ulid CustomerId { get; set; }
}