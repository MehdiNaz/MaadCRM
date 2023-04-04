namespace Domain.Models.Customers;

public class ProductCustomerFavoritesList
{
    public ProductCustomerFavoritesList()
    {
        ProductId = Ulid.NewUlid();
        ProductCustomerFavoritesListStatus = Status.Show;
    }

    public Ulid ProductId { get; set; }
    public Ulid CustomerId { get; set; }
    public Status ProductCustomerFavoritesListStatus { get; set; }

    public Product Product { get; set; }
    public Customer Customer { get; set; }
}