namespace Domain.Models.Customers;

public class CustomerActivity : BaseEntity
{
    public CustomerActivity()
    {
        CustomerActivityId = Ulid.NewUlid();
        CustomerActivityStatus = Status.Show;
    }

    public Ulid CustomerActivityId { get; set; }
    public string CustomerActivityName { get; set; }
    public string CustomerActivityDescription { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomerActivityStatus { get; set; }
    // public Customer Customer { get; set; }
    // public ICollection<CustomerActivityHistory>? CustomerActivityHistories { get; set; }
}