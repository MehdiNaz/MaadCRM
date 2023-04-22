using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshOrderService.Commands;

public struct CreateForoshOrderCommand : IRequest<ForooshOrder>
{
    public DateOnly PaymentDate { get; set; }
    public decimal Price { get; set; }
    public decimal ShippingPrice { get; set; }
    public decimal PriceTotal { get; set; }
    public decimal DiscountPrice { get; set; }
    public string Description { get; set; }
    public PaymentMethodTypes PaymentMethodType { get; set; }
    public ShippingMethodTypes ShippingMethodType { get; set; }
    public Ulid ProductId { get; set; }
}