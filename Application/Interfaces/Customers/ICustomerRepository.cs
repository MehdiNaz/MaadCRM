namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    ValueTask<ICollection<Customer?>> GetAllCustomersAsync(Ulid customerId);
    ValueTask<Customer?> GetCustomerByIdAsync(Ulid customerId);
    ValueTask<Customer?> CreateCustomerAsync(CreateCustomerCommand entity);
    ValueTask<Customer?> UpdateCustomerAsync(Customer entity);
    ValueTask<Customer?> DeleteCustomerAsync(Ulid customerId);
}