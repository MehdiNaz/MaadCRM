namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    ValueTask<ICollection<Customer?>> GetAllCustomersAsync(string userId);
    ValueTask<Customer?> GetCustomerByIdAsync(Ulid customerId);
    ValueTask<Customer?> ChangeStatusCustomerByIdAsync(Status status, Ulid customerId);
    ValueTask<Customer?> CreateCustomerAsync(CreateCustomerCommand entity);
    ValueTask<Customer?> UpdateCustomerAsync(UpdateCustomerCommand entity);
    ValueTask<Customer?> DeleteCustomerAsync(Ulid customerId);
}