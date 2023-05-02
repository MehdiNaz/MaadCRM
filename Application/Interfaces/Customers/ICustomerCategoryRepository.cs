namespace Application.Interfaces.Customers;

public interface ICustomerCategoryRepository
{
    ValueTask<Result<ICollection<CustomerFeedbackCategory>>> GetAllCustomerCategoryAsync(string userId);
    ValueTask<Result<CustomerFeedbackCategory>> GetCustomerCategoryByIdAsync(Ulid customerCategoryId, string userId);
    ValueTask<Result<CustomerFeedbackCategory>> ChangeStatusCustomerCategoryByIdAsync(ChangeStatusCustomerCategoryCommand request);
    ValueTask<Result<CustomerFeedbackCategory>> CreateCustomerCategoryAsync(CreateCustomerCategoryCommand request);
    ValueTask<Result<CustomerFeedbackCategory>> UpdateCustomerCategoryAsync(UpdateCustomerCategoryCommand request);
    ValueTask<Result<CustomerFeedbackCategory>> DeleteCustomerCategoryAsync(Ulid id);
}