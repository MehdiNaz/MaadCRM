namespace Application.Services.Customer.Foroosh.PaymentService.Queries;

public struct AllPaymentsQuery : IRequest<Result<ICollection<ForooshPayment>>>
{
}