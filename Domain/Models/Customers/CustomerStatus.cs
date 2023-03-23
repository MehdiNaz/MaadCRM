namespace Domain.Models.Customers;

public class CustomerStatus:BaseEntity
{
    public int StatusName { get; set; }
    public int DisplayOrder { get; set; }
    public ICollection<CustomerStatusHistory> CustomerStatusHistory { get; set; }
}