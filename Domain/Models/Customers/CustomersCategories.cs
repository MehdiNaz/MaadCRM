namespace Domain.Models.Customers;

public class CustomersCategories : BaseEntity
{
    public Ulid CustomersCategoryId { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid CategoryId { get; set; }

    public ICollection<Customer> Customers { get; set; }
    public ICollection<CustCategory> CustomerCategories { get; set; }
}