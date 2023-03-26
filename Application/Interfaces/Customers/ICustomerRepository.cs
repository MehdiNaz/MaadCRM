namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    Task<ICollection<Customer?>> GetAllCustomersAsync();
    ValueTask<Customer?> GetCustomerByIdAsync(int customerId);
    ValueTask<Customer?> CreateCustomerAsync(Customer? toCreate);
    ValueTask<Customer?> UpdateCustomerAsync(string updateContent, int customerId);
    ValueTask DeleteCustomerAsync(int customerId);
}