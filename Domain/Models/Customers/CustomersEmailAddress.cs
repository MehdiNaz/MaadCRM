namespace Domain.Models.Customers;

public class CustomersEmailAddress : BaseEntity
{
    public CustomersEmailAddress()
    {
        Id = Ulid.NewUlid();
        StatusCustomerEmailAddress = Status.Show;
    }

    public Ulid Id { get; set; }
    public required string CustomerEmailAddress { get; set; }
    public Status StatusCustomerEmailAddress { get; set; }
    

    public required Ulid IdCustomer { get; set; }

    public virtual Customer? IdCustomerNavigation { get; set; }
    
    public uint RowVersion { get; set; }
}
