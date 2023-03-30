namespace Domain.Models.Customers;

public class ProductCustomerFavoritesList
{
    public ProductCustomerFavoritesList()
    {
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid ProductId { get; set; }
    public Ulid CustomerId { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public ICollection<Product> Products { get; set; }
    public ICollection<Customer> Customers { get; set; }
}