namespace Application.Interfaces.Customers;

public interface ICustomerFeedbackRepository
{
    ValueTask<ICollection<CustomerFeedback?>> GetAllCustomerFeedbacksAsync();
    ValueTask<CustomerFeedback?> GetCustomerFeedbackByIdAsync(Ulid customerFeedbackId);
    ValueTask<CustomerFeedback?> ChangeStatusCustomerFeedbackByIdAsync(Status status, Ulid customerFeedbackId);
    ValueTask<CustomerFeedback?> CreateCustomerFeedbackAsync(CustomerFeedback? entity);
    ValueTask<CustomerFeedback?> UpdateCustomerFeedbackAsync(CustomerFeedback entity);
    ValueTask<CustomerFeedback?> DeleteCustomerFeedbackAsync(Ulid customerFeedbackId);
}