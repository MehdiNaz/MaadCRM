namespace Application.Services.ForoshFactorService.Commands;

public struct UpdateForoshFactorCommand : IRequest<ForoshFactor>
{
    public Ulid ForoshFactorId { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal FinalTotal { get; set; }
}