namespace Application.Interfaces.Customers.Feedback;

public interface ICustomerFeedbackRepository
{
    ValueTask<Result<ICollection<CustomerFeedback>>> GetAllCustomerFeedbacksAsync();
    ValueTask<Result<CustomerFeedback>> GetCustomerFeedbackByIdAsync(Ulid feedbackId);
    ValueTask<Result<ICollection<CustomerFeedback>>> SearchByItemsAsync(string request);
    ValueTask<Result<CustomerFeedback>> ChangeStatusCustomerFeedbacksByIdAsync(ChangeStateCustomerFeedbackCommand request);
    ValueTask<Result<CustomerFeedback>> CreateCustomerFeedbackAsync(CreateCustomerFeedbackCommand request);
    ValueTask<Result<CustomerFeedback>> UpdateCustomerFeedbackAsync(UpdateCustomerFeedbackCommand request);
    ValueTask<Result<CustomerFeedback>> DeleteCustomerFeedbackAsync(Ulid id);
}
