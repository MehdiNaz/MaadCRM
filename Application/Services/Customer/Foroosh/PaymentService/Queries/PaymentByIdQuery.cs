namespace Application.Services.Customer.Foroosh.PaymentService.Queries;

public struct PaymentByIdQuery : IRequest<Result<Payment>>
{
    public Ulid Id { get; set; }
}