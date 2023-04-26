namespace Application.Interfaces.Customers;

public interface ICustomerFeedbackRepository
{
    ValueTask<ICollection<CustomerFeedback?>> GetAllCustomerFeedbacksAsync();
    ValueTask<CustomerFeedback?> GetCustomerFeedbackByIdAsync(Ulid customerFeedbackId);
    ValueTask<CustomerFeedback?> ChangeStatusCustomerFeedbackByIdAsync(ChangeStatusCustomerFeedBackCommand request);
    ValueTask<CustomerFeedback?> CreateCustomerFeedbackAsync(CreateCustomerFeedBackCommand request);
    ValueTask<CustomerFeedback?> UpdateCustomerFeedbackAsync(UpdateCustomerFeedBackCommand request);
    ValueTask<CustomerFeedback?> DeleteCustomerFeedbackAsync(Ulid id);
}