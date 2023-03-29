namespace Application.Services.CustomerService.Query;

public struct GetCustomerByIdQuery : IRequest<Customer?>
{
    public Ulid CustomerId { get; set; }
}