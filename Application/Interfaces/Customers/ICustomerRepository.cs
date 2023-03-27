namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    Task<ICollection<Customer?>> GetAllCustomersAsync();
    ValueTask<Customer?> GetCustomerByIdAsync(Ulid customerId);
    ValueTask<Customer?> CreateCustomerAsync(Customer? entity);
    ValueTask<Customer?> UpdateCustomerAsync(Customer entity, Ulid customerId);
    ValueTask<Customer?> DeleteCustomerAsync(Ulid customerId);
}