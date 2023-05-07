namespace Application.Services.Customer.Foroosh.PaymentService.Commands;

public struct DeletePaymentCommand : IRequest<Result<Payment>>
{
    public Ulid Id { get; set; }
}