using Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Commands;

namespace DataAccess.Repositories.Customers.Feedback;

public class CustomerFeedbackCategoryRepository: ICustomerFeedbackCategoryRepository
{
    public async ValueTask<Result<ICollection<CustomerFeedbackCategory>>> GetAllCustomerFeedbackCategoriesAsync(Ulid businessId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> GetCustomerFeedbackCategoryByIdAsync(Ulid feedbackId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<ICollection<CustomerFeedbackCategory>>> SearchByItemsAsync(string request)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> ChangeStatusCustomerFeedbackCategoryByIdAsync(ChangeStateCustomerFeedbackCategoryCommand request)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> CreateCustomerFeedbackCategoryAsync(CreateCustomerFeedbackCategoryCommand request)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> UpdateCustomerFeedbackCategoryAsync(UpdateCustomerFeedbackCategoryCommand request)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Result<CustomerFeedbackCategory>> DeleteCustomerFeedbackCategoryAsync(Ulid id)
    {
        throw new NotImplementedException();
    }
}