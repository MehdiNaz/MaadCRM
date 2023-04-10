namespace Domain.Models.Customers;

public class CustomersAddress : BaseEntity
{
    public CustomersAddress()
    {
        CustomersAddressId = Ulid.NewUlid();
        CustomersAddressStatus = Status.Show;
    }

    public Ulid CustomersAddressId { get; set; }
    public string Address { get; set; }
    public string? CodePost { get; set; }
    public string? PhoneNo { get; set; }
    public string? Description { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomersAddressStatus { get; set; }

    // public Customer Customer { get; set; }
    public ICollection<ForoshFactor>? ForoshFactors { get; set; }
}