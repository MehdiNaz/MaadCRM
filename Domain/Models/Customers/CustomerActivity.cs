namespace Domain.Models.Customers;

public class CustomerActivity : BaseEntity
{
    public Ulid CustomerActivityId { get; set; }
    public string CustomerActivityName { get; set; }
    public string CustomerActivityDescription { get; set; }
   
    public Ulid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<CustomerActivityHistory>? CustomerActivityHistories { get; set; }
}