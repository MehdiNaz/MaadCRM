namespace Application.Services.Customer.Foroosh.PaymentService.Queries;

public struct PaymentByIdQuery : IRequest<Result<ForooshPayment>>
{
    public Ulid Id { get; set; }
}