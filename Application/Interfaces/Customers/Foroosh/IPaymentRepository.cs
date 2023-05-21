using Application.Responses.Customer.Foroosh;

namespace Application.Interfaces.Customers.Foroosh;

public interface IForooshPaymentRepository
{
    ValueTask<Result<ICollection<ForooshPayment>>> GetAllPaymentsAsync();
    ValueTask<Result<ForooshPayment>> GetPaymentByIdAsync(Ulid paymentId);
    ValueTask<Result<ForooshPayment>> ChangeStatusPaymentByIdAsync(ChangeStatusPaymentCommand request);
    ValueTask<Result<ForooshPayment>> CreatePaymentAsync(CreatePaymentCommand request);
    ValueTask<Result<ForooshPayment>> UpdatePaymentAsync(UpdatePaymentCommand request);
    ValueTask<Result<ForooshPayment>> DeletePaymentAsync(Ulid paymentId);
    ValueTask<Result<SaveForooshPaymentResponse>> SavePaymentsAsync(SaveForooshPaymentCommand request);
}