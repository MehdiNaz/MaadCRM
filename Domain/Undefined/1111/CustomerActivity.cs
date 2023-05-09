namespace Domain.Models.Customers;

public class CustomerActivity : BaseEntity
{
    public CustomerActivity()
    {
        Id = Ulid.NewUlid();
        CustomerActivityStatusType = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public string CustomerActivityName { get; set; }
    public string CustomerActivityDescription { get; set; }
    public Ulid CustomerId { get; set; }
    public StatusType CustomerActivityStatusType { get; set; }
    // public Customer Customer { get; set; }
    // public ICollection<CustomerActivityHistory>? CustomerActivityHistories { get; set; }
}