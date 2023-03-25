namespace Domain.Models.Customers;

public class CustCategory : BaseEntity
{
    public Ulid CustCategoryId { get; set; }
    public string CustomerCategoryName { get; set; }
    public byte IsDeleted { get; set; }
    public byte IsShown { get; set; }
    public Ulid CategoryId { get; set; }

    public CustomersCategories CustomersCategories { get; set; }
}