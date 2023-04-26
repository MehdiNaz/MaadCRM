namespace Application.Interfaces.Customers;

public interface ICustomerCategoryRepository
{
    ValueTask<ICollection<CustomerCategory?>> GetAllCustomerCategoryAsync(string userId);
    ValueTask<CustomerCategory?> GetCustomerCategoryByIdAsync(Ulid customerCategoryId, string userId);
    ValueTask<CustomerCategory?> ChangeStatusCustomerCategoryByIdAsync(ChangeStatusCustomerCategoryCommand request);
    ValueTask<CustomerCategory?> CreateCustomerCategoryAsync(CreateCustomerCategoryCommand request);
    ValueTask<CustomerCategory?> UpdateCustomerCategoryAsync(UpdateCustomerCategoryCommand request);
    ValueTask<CustomerCategory?> DeleteCustomerCategoryAsync(Ulid id);
}