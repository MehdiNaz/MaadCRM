namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    ValueTask<ICollection<Customer?>> GetAllCustomersAsync();
    ValueTask<Customer?> GetCustomerByIdAsync(Ulid customerId);
    ValueTask<Customer?> CreateCustomerAsync(Customer? entity);
    ValueTask<Customer?> UpdateCustomerAsync(Customer entity);
    ValueTask<Customer?> DeleteCustomerAsync(Ulid customerId);
}