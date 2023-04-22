using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.Commands;

public struct UpdateForoshFactorCommand : IRequest<ForooshFactor>
{
    public Ulid Id { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal FinalTotal { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid CustomersAddressId { get; set; }
}