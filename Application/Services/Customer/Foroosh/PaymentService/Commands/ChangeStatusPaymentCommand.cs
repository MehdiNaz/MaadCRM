namespace Application.Services.Customer.Foroosh.PaymentService.Commands;

public struct ChangeStatusPaymentCommand : IRequest<Result<Payment>>
{
    public Ulid Id { get; set; }
    public StatusType PaymentStatusType { get; set; }
}