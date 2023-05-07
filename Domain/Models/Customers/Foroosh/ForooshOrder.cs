namespace Domain.Models.Customers.Foroosh;

public sealed class ForooshOrder : BaseEntityWithUserUpdate
{
    public ForooshOrder()
    {
        Id = Ulid.NewUlid();
        StatusForooshOrder = Status.Show;
    }

    public Ulid Id { get; set; }
    public decimal Price { get; set; }
    public decimal PriceTotal { get; set; }
    public uint Tedad { get; set; }
    public decimal PriceDiscount { get; set; }
    public decimal PriceShipping { get; set; }
    public Status StatusForooshOrder { get; set; }


    public Ulid IdProduct { get; set; }
    public Product IdProductNavigation { get; set; }

    public required Ulid IdForooshFactor { get; set; }
    public ForooshFactor? IdForooshFactorNavigation { get; set; }
}