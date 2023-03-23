namespace Domain.Models.Customers;

public class CustomerActivity:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<CustomerActivityHistory> CustomerActivityHistories { get; set; }
}