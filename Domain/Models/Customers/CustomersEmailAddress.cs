namespace Domain.Models.Customers;

public class CustomersEmailAddress : BaseEntity
{
    public CustomersEmailAddress()
    {
        Id = Ulid.NewUlid();
        CustomersEmailAddressStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public string CustomersEmailAddrs { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomersEmailAddressStatus { get; set; }

    // public Customer Customer { get; set; }
}
