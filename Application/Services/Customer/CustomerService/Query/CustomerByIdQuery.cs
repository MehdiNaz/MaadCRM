namespace Application.Services.Customer.CustomerService.Query;

public struct CustomerByIdQuery : IRequest<Result<CustomerResponse>>
{
    public Ulid CustomerId { get; set; }
    public string UserId { get; set; }
}