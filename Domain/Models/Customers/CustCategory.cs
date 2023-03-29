namespace Domain.Models.Customers;

public class CustCategory : BaseEntity
{
    public CustCategory()
    {
        IsDeleted = Status.NotDeleted;
    }

    public Ulid CustCategoryId { get; set; }
    public string CustomerCategoryName { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public ICollection<Customer> Customers { get; set; }
}