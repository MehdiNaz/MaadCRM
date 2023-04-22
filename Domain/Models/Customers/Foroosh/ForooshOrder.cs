namespace Domain.Models.Customers.Foroosh;

public class ForooshOrder : BaseEntity
{
    public ForooshOrder()
    {
        Id = Ulid.NewUlid();
        StatusForooshOrder = Status.Show;
    }

    public Ulid Id { get; set; }
    public DateOnly DatePayment { get; set; }
    public decimal Price { get; set; }
    public decimal PriceShipping { get; set; }
    public decimal PriceTotal { get; set; }
    public decimal PriceDiscount { get; set; }
    public string Description { get; set; }
    public PaymentMethodTypes PaymentMethodType { get; set; }
    public ShippingMethodTypes ShippingMethodType { get; set; }
    public Status StatusForooshOrder { get; set; }
    
    public Ulid IdProduct { get; set; }
    public virtual Product IdProductNavigation { get; set; }

    public required Ulid IdForooshFactor { get; set; }
    public virtual ForooshFactor? IdForooshFactorNavigation { get; set; }
    
    public uint Version { get; set; }
}