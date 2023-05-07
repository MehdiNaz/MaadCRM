namespace Application.Services.ForoshOrderService.Commands;

public struct CreateForoshOrderCommand : IRequest<ForooshOrder>
{
    public decimal Price { get; set; }
    public decimal ShippingPrice { get; set; }
    public decimal PriceTotal { get; set; }
    public decimal DiscountPrice { get; set; }
    public ShippingMethodTypes ShippingMethodType { get; set; }
    public Ulid ProductId { get; set; }
}