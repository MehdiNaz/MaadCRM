namespace Domain.Models.Customers.Foroosh;

public class ForooshFactor : BaseEntity
{
    public ForooshFactor()
    {
        Id = Ulid.NewUlid();
        StatusForooshFactor = Status.Show;
        ForooshOrders = new HashSet<ForooshOrder>();
    }

    public Ulid Id { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal PriceTotal { get; set; }
    public Status StatusForooshFactor { get; set; }
    
    
    
    public required Ulid IdCustomer { get; set; }
    public virtual Customer IdCustomerNavigation { get; set; }
    
    
    public required Ulid? IdCustomerAddress { get; set; }
    public CustomerAddress? IdCustomerAddressNavigation { get; set; }

    public virtual ICollection<ForooshOrder> ForooshOrders { get; set; }

    
    public uint Version { get; set; }
}