namespace Application.Services.Customer.Foroosh.ForooshOrderService.Commands;

public struct CreateForooshOrderCommand : IRequest<ForooshOrder>
{
    public decimal Price { get; set; }
    public decimal ShippingPrice { get; set; }
    public decimal PriceTotal { get; set; }
    public decimal DiscountPrice { get; set; }
    public ShippingMethodTypes ShippingMethodType { get; set; }
    public Ulid ProductId { get; set; }
    public Ulid FactorId { get; set; }
}