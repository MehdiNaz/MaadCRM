namespace Application.Services.CustomerService.Query;

public class GetCustomerByIdQuery : IRequest<Customer?>
{
    public Ulid CustomerId { get; set; }
}