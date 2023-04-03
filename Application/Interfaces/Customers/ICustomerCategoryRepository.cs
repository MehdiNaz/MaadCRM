namespace Application.Interfaces.Customers;

public interface ICustomerCategoryRepository
{
    Task<ICollection<CustomerCategory?>> GetAllCustomerCategoryAsync();
    ValueTask<CustomerCategory?> GetCustomerCategoryByIdAsync(Ulid CustomerCategoryId);
    ValueTask<CustomerCategory?> CreateCustomerCategoryAsync(CustomerCategory? entity);
    ValueTask<CustomerCategory?> UpdateCustomerCategoryAsync(CustomerCategory entity, Ulid CustomerCategoryId);
    ValueTask<CustomerCategory?> DeleteCusCustomerAsync(Ulid CustomerCategoryId);
}