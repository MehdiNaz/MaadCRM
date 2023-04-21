namespace Domain.Models.Customers.Forosh;

public class ForooshOrder : BaseEntity
{
    public ForooshOrder()
    {
        Id = Ulid.NewUlid();
        ForoshOrderStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public DateOnly PaymentDate { get; set; }
    public decimal Price { get; set; }
    public decimal ShippingPrice { get; set; }
    public decimal PriceTotal { get; set; }
    public decimal DiscountPrice { get; set; }
    public string Description { get; set; }
    public PaymentMethodTypes PaymentMethodType { get; set; }
    public ShippingMethodTypes ShippingMethodType { get; set; }
    public Status ForoshOrderStatus { get; set; }
    public Ulid ProductId { get; set; }

    // public Product Product { get; set; }
}