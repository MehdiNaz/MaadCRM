namespace Domain.Models.Customers;

public class CustomersEmailAddress : BaseEntity
{
    public CustomersEmailAddress()
    {
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid CustomersEmailAddressId { get; set; }
    public string CustomersEmailAddrs { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public ICollection<Customer> EmaCollection{ get; set; }
}
