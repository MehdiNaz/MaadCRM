namespace Application.Services.Customer.CustomerService.Commands;

public struct DeleteCustomerCommand : IRequest<string>
{
    public Ulid CustomerId { get; set; }
}