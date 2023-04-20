namespace Domain.Models.Customers.Forosh;

public class ForoshFactor : BaseEntity
{
    public ForoshFactor()
    {
        Id = Ulid.NewUlid();
        ForoshFactorStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal FinalTotal { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid CustomersAddressId { get; set; }
    public Status ForoshFactorStatus { get; set; }

    // public Customer Customer { get; set; }
    public CustomersAddress CustomersAddress { get; set; }
}