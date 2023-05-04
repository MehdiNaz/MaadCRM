namespace Application.Interfaces.Customers.Feedback;

public interface ICustomerFeedbackCategoryRepository
{
    ValueTask<Result<ICollection<CustomerFeedbackCategoryResponse>>> GetAllCustomerFeedbackCategoriesAsync(Ulid businessId);
    ValueTask<Result<CustomerFeedbackCategoryResponse>> GetCustomerFeedbackCategoryByIdAsync(Ulid feedbackCategoryId);
    ValueTask<Result<ICollection<CustomerFeedbackCategoryResponse>>> SearchByItemsAsync(Ulid businessId,string request);
    ValueTask<Result<CustomerFeedbackCategoryResponse>> ChangeStatusCustomerFeedbackCategoryByIdAsync(ChangeStatusCustomerFeedbackCategoryCommand request);
    ValueTask<Result<CustomerFeedbackCategoryResponse>> CreateCustomerFeedbackCategoryAsync(CreateCustomerFeedbackCategoryCommand request);
    ValueTask<Result<CustomerFeedbackCategoryResponse>> UpdateCustomerFeedbackCategoryAsync(UpdateCustomerFeedbackCategoryCommand request);
    ValueTask<Result<CustomerFeedbackCategoryResponse>> DeleteCustomerFeedbackCategoryAsync(Ulid feedbackCategoryId);
}
