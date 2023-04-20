namespace Application.Services.ForoshFactorService.Commands;

public struct CreateForoshFactorCommand : IRequest<ForoshFactor>
{
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal FinalTotal { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid CustomersAddressId { get; set; }
}