namespace Domain.Models.Customers;

public class ProductCustomerFavoritesList : BaseEntity
{
    public ProductCustomerFavoritesList()
    {
        // Id = Ulid.NewUlid();
        StatusTypeProductCustomerFavoritesList = StatusType.Show;
    }

    // public Ulid Id { get; set; }
    public StatusType StatusTypeProductCustomerFavoritesList { get; set; }

    
    public Ulid IdProduct { get; set; }
    public virtual Product? IdProductNavigation { get; set; }
    
    public Ulid IdCustomer { get; set; }
    public virtual Customer? IdCustomerNavigation { get; set; }
    
}
