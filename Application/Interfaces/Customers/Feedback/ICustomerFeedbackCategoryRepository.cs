namespace Application.Interfaces.Customers.Feedback;

public interface ICustomerFeedbackCategoryRepository
{
    ValueTask<Result<ICollection<CustomerFeedbackCategory>>> GetAllCustomerFeedbackCategoriesAsync(Ulid businessId);
    ValueTask<Result<CustomerFeedbackCategory>> GetCustomerFeedbackCategoryByIdAsync(Ulid feedbackCategoryId);
    ValueTask<Result<ICollection<CustomerFeedbackCategory>>> SearchByItemsAsync(string request);
    ValueTask<Result<CustomerFeedbackCategory>> ChangeStatusCustomerFeedbackCategoryByIdAsync(ChangeStatusCustomerFeedbackCategoryCommand request);
    ValueTask<Result<CustomerFeedbackCategory>> CreateCustomerFeedbackCategoryAsync(CreateCustomerFeedbackCategoryCommand request);
    ValueTask<Result<CustomerFeedbackCategory>> UpdateCustomerFeedbackCategoryAsync(UpdateCustomerFeedbackCategoryCommand request);
    ValueTask<Result<CustomerFeedbackCategory>> DeleteCustomerFeedbackCategoryAsync(Ulid feedbackCategoryId);
}
