namespace Application.Responses;

public class ForooshPaymentResponse
{
    public Ulid Id { get; set; }
    public DateTime DatePay { get; set; }
    public decimal PaymentAmount { get; set; }
    public StatusType PaymentStatusType { get; set; }
}