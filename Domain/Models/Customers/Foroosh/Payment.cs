namespace Domain.Models.Customers.Foroosh;

public class Payment : BaseEntity
{
    public Payment()
    {
        Id = Ulid.NewUlid();
        PaymentStatusType = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public DateTime DatePay { get; set; }
    public decimal PaymentAmount { get; set; }
    public StatusType PaymentStatusType { get; set; }

    //// در صورت عیر نقدی بودن
    //public DateTime StartDatePay { get; set; }

    public required Ulid IdForooshFactor { get; set; }
    public ForooshFactor IdForooshFactorNavigation { get; set; }
}