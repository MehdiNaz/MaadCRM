namespace Domain.Models.Customers;

public class CustomerCategory : BaseEntity
{
    public CustomerCategory()
    {
        Id = Ulid.NewUlid();
        CustomerCategoryStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public string CustomerCategoryName { get; set; }
    public Status CustomerCategoryStatus { get; set; }
    public string UserId { get; set; }

    public ICollection<Customer>? Customers { get; set; }
}