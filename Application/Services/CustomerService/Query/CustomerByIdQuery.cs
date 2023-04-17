namespace Application.Services.CustomerService.Query;

public struct CustomerByIdQuery : IRequest<CustomerResponse>
{
    public Ulid CustomerId { get; set; }
}