namespace Application.Services.Customer.Foroosh.PaymentService.Commands;

public struct DeletePaymentCommand : IRequest<Result<ForooshPayment>>
{
    public Ulid Id { get; set; }
}