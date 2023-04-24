namespace Application.Services.CustomerService.Query;

public struct CustomerByIdQuery : IRequest<Result<CustomerResponse>>
{
    public Ulid CustomerId { get; set; }
}