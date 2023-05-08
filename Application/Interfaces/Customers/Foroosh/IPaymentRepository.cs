namespace Application.Interfaces.Customers.Foroosh;

public interface IPaymentRepository
{
    ValueTask<Result<ICollection<Payment>>> GetAllPaymentsAsync();
    ValueTask<Result<Payment>> GetPaymentByIdAsync(Ulid paymentId);
    ValueTask<Result<Payment>> ChangeStatusPaymentByIdAsync(ChangeStatusPaymentCommand request);
    ValueTask<Result<Payment>> CreatePaymentAsync(CreatePaymentCommand request);
    ValueTask<Result<Payment>> UpdatePaymentAsync(UpdatePaymentCommand request);
    ValueTask<Result<Payment>> DeletePaymentAsync(Ulid paymentId);
}