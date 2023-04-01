namespace Domain.Models.Customers;

public class ProductCustomerFavoritesList
{
    public ProductCustomerFavoritesList()
    {
        ProductId = Ulid.NewUlid();
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid ProductId { get; set; }
    public Ulid CustomerId { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public Product Product { get; set; }
    public Customer Customer { get; set; }
}