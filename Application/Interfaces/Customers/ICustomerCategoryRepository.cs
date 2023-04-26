namespace Application.Interfaces.Customers;

public interface ICustomerCategoryRepository
{
    ValueTask<Result<ICollection<CustomerCategory>>> GetAllCustomerCategoryAsync(string userId);
    ValueTask<Result<CustomerCategory>> GetCustomerCategoryByIdAsync(Ulid customerCategoryId, string userId);
    ValueTask<Result<CustomerCategory>> ChangeStatusCustomerCategoryByIdAsync(ChangeStatusCustomerCategoryCommand request);
    ValueTask<Result<CustomerCategory>> CreateCustomerCategoryAsync(CreateCustomerCategoryCommand request);
    ValueTask<Result<CustomerCategory>> UpdateCustomerCategoryAsync(UpdateCustomerCategoryCommand request);
    ValueTask<Result<CustomerCategory>> DeleteCustomerCategoryAsync(Ulid id);
}