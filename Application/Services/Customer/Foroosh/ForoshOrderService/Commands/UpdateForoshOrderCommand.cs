namespace Application.Services.Customer.Foroosh.ForooshOrderService.Commands;

public struct UpdateForooshOrderCommand : IRequest<ForooshOrder>
{
    public Ulid Id { get; set; }
    public decimal Price { get; set; }
    public decimal ShippingPrice { get; set; }
    public decimal PriceTotal { get; set; }
    public decimal DiscountPrice { get; set; }
}