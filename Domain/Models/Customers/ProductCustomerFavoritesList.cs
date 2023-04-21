namespace Domain.Models.Customers;

public class ProductCustomerFavoritesList : BaseEntity
{
    public ProductCustomerFavoritesList()
    {
        // Id = Ulid.NewUlid();
        StatusProductCustomerFavoritesList = Status.Show;
    }

    // public Ulid Id { get; set; }
    public Status StatusProductCustomerFavoritesList { get; set; }

    
    public Ulid IdProduct { get; set; }
    public virtual Product? IdProductNavigation { get; set; }
    
    public Ulid IdCustomer { get; set; }
    public virtual Customer? IdCustomerNavigation { get; set; }
    
    public byte[] RowVersion { get; set; }
    
    // public Product Product { get; set; }
    // public Customer Customer { get; set; }
}
