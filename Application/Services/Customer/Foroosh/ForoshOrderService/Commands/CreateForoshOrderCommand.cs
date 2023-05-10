namespace Application.Services.Customer.Foroosh.ForoshOrderService.Commands;

public struct CreateForooshOrderCommand : IRequest<Result<ForooshOrder>>
{
    public decimal Price { get; set; }
    public decimal ShippingPrice { get; set; }
    public decimal PriceTotal { get; set; }
    public decimal DiscountPrice { get; set; }
    public ShippingMethodTypes ShippingMethodType { get; set; }
    public Ulid ProductId { get; set; }
    public Ulid FactorId { get; set; }
}