namespace Application.Services.ForoshFactorService.Commands;

public struct UpdateForoshFactorCommand : IRequest<Result<ForooshFactor>>
{
    public Ulid Id { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid CustomersAddressId { get; set; }
}