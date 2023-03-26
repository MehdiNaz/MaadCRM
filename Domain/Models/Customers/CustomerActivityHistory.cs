namespace Domain.Models.Customers;

public class CustomerActivityHistory : BaseEntity
{
    public Ulid CustomerActivityHistoryId { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid CustomerActivityId { get; set; }
    public string Description { get; set; }
    public bool IsActivePoint { get; set; }
   
    
    
    //[ForeignKey(nameof(CustomerId))]
    public Customer Customers { get; set; }
    //[ForeignKey(nameof(CustomerActivityId))]
    public CustomerActivity CustomerActivity { get; set; }
}