namespace Application.Interfaces.Customers;

public interface ICustomerFeedbackFeedback
{
    ValueTask<ICollection<CustomerFeedback?>> GetAllCustomerFeedbacksAsync();
    ValueTask<CustomerFeedback?> GetCustomerFeedbackByIdAsync(Ulid customerFeedbackId);
    ValueTask<CustomerFeedback?> CreateCustomerFeedbackAsync(CustomerFeedback? entity);
    ValueTask<CustomerFeedback?> UpdateCustomerFeedbackAsync(CustomerFeedback entity);
    ValueTask<CustomerFeedback?> DeleteCustomerFeedbackAsync(Ulid customerFeedbackId);
}