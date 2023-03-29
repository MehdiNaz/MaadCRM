namespace Application.Services.CustomerService.Commands;

public struct DeleteCustomerCommand : IRequest<Customer>
{
    public Ulid CustomerId { get; set; }
}