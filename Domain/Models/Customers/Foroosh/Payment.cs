namespace Domain.Models.Customers.Foroosh;

public class Payment : BaseEntity
{
    public Payment()
    {
        Id = Ulid.NewUlid();
        PaymentStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public Ulid IdFactor { get; set; }
    public DateTime DatePay { get; set; }
    public decimal Amount { get; set; }
    public Status PaymentStatus { get; set; }
    public required Ulid IdForooshFactor { get; set; }
    public ForooshFactor IdForooshFactorNavigation { get; set; }
}