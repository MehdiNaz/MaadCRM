namespace Domain.Models.Customers;

public class CustomersEmailAddress : BaseEntity
{
    public CustomersEmailAddress()
    {
        IsDeleted = (byte)Status.NotDeleted;
    }

    public Ulid CustomersEmailAddressId { get; set; }
    public string CustomersEmailAddrs { get; set; }
    public byte IsDeleted { get; set; }


    public ICollection<Customer> EmaCollection{ get; set; }
}
