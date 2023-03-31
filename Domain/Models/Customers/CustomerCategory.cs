namespace Domain.Models.Customers;

public class CustomerCategory : BaseEntity
{
    public CustomerCategory()
    {
        IsDeleted = Status.NotDeleted;
    }

    public Ulid CustomerCategoryId { get; set; }
    public string CustomerCategoryName { get; set; }
    public Ulid CustomerId { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public ICollection<Customer> Customers { get; set; }
}