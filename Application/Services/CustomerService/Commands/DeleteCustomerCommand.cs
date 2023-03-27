namespace Application.Services.CustomerService.Commands;

public class DeleteCustomerCommand : IRequest<Customer>
{
    public Ulid CustomerId { get; set; }
}