namespace Application.Interfaces.Customers.Feedback;

public interface ICustomerFeedbackRepository
{
    ValueTask<Result<ICollection<CustomerFeedbackResponse>>> GetAllCustomerFeedbacksAsync();
    ValueTask<Result<CustomerFeedbackResponse>> GetCustomerFeedbackByIdAsync(Ulid feedbackId);
    ValueTask<Result<ICollection<CustomerFeedbackResponse>>> SearchByItemsAsync(string request);
    ValueTask<Result<CustomerFeedbackResponse>> ChangeStatusCustomerFeedbacksByIdAsync(ChangeStateCustomerFeedbackCommand request);
    ValueTask<Result<CustomerFeedbackResponse>> CreateCustomerFeedbackAsync(CreateCustomerFeedbackCommand request);
    ValueTask<Result<CustomerFeedbackResponse>> UpdateCustomerFeedbackAsync(UpdateCustomerFeedbackCommand request);
    ValueTask<string> DeleteCustomerFeedbackAsync(Ulid id);
}
