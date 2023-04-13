namespace Application.Interfaces.Customers;

public interface ICustomerCategoryRepository
{
    ValueTask<ICollection<CustomerCategory?>> GetAllCustomerCategoryAsync(string userId);
    ValueTask<CustomerCategory?> GetCustomerCategoryByIdAsync(Ulid customerCategoryId, string userId);
    ValueTask<CustomerCategory?> ChangeStatusCustomerCategoryByIdAsync(Status status, Ulid customerCategoryId);
    ValueTask<CustomerCategory?> CreateCustomerCategoryAsync(CustomerCategory? entity);
    ValueTask<CustomerCategory?> UpdateCustomerCategoryAsync(CustomerCategory entity);
    ValueTask<CustomerCategory?> DeleteCusCustomerAsync(Ulid customerCategoryId, string userId);
}