namespace Domain.Models.Customers;

public class CustomersEmailAddress : BaseEntity
{
    public CustomersEmailAddress()
    {
        CustomersEmailAddressId = Ulid.NewUlid();
        CustomersEmailAddressStatus = Status.Show;
    }

    public Ulid CustomersEmailAddressId { get; set; }
    public string CustomersEmailAddrs { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomersEmailAddressStatus { get; set; }

    // public Customer Customer { get; set; }
}
