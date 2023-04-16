namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    ValueTask<ICollection<CustomerResponse>> GetAllCustomersAsync(string userId);
    ValueTask<CustomerResponse> GetCustomerByIdAsync(Ulid customerId);
    ValueTask<ICollection<CustomerResponse>?> SearchByItemsAsync(CustomerBySearchItemsQuery search);
    Task<CustomerResponse?> ChangeStatusCustomerByIdAsync(Status status, Ulid customerId);
    Task<CustomerResponse?> CreateCustomerAsync(CreateCustomerCommand entity);
    Task<CustomerResponse?> UpdateCustomerAsync(UpdateCustomerCommand entity);
    Task<CustomerResponse?> DeleteCustomerAsync(Ulid customerId);
}