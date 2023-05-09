namespace Domain.Models.Customers;

public class CustomersEmailAddress : BaseEntity
{
    public CustomersEmailAddress()
    {
        Id = Ulid.NewUlid();
        StatusTypeCustomerEmailAddress = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public required string CustomerEmailAddress { get; set; }
    public StatusType StatusTypeCustomerEmailAddress { get; set; }
    

    public required Ulid IdCustomer { get; set; }

    public virtual Customer? IdCustomerNavigation { get; set; }
}
