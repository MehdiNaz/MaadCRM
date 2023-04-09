namespace Application.Services.CustomerService.Query;

public struct CustomerByIdQuery : IRequest<Customer?>
{
    public Ulid CustomerId { get; set; }
}