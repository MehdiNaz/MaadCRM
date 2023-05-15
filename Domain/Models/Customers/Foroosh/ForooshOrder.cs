namespace Domain.Models.Customers.Foroosh;

public sealed class ForooshOrder : BaseEntityWithUserUpdate
{
    public ForooshOrder()
    {
        Id = Ulid.NewUlid();
        StatusTypeForooshOrder = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public decimal Price { get; set; }
    public decimal PriceTotal { get; set; }
    public uint Tedad { get; set; }
    public decimal PriceDiscount { get; set; } // تخفیف بخش فروش
    public decimal PriceShipping { get; set; }
    public StatusType StatusTypeForooshOrder { get; set; }


    public Ulid IdProduct { get; set; }
    public Product IdProductNavigation { get; set; }

    public required Ulid IdForooshFactor { get; set; }
    public ForooshFactor? IdForooshFactorNavigation { get; set; }
}