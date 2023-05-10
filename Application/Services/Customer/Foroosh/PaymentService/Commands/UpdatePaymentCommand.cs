namespace Application.Services.Customer.Foroosh.PaymentService.Commands;

public struct UpdatePaymentCommand : IRequest<Result<Payment>>
{
    public Ulid Id { get; set; }
    public DateTime DatePay { get; set; }
    public decimal PaymentAmount { get; set; }
}