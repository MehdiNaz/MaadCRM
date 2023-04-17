namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    ValueTask<ICollection<CustomerResponse>> GetAllCustomersAsync(string userId);
    ValueTask<CustomerResponse> GetCustomerByIdAsync(Ulid customerId);
    ValueTask<ICollection<CustomerResponse>?> FilterByItemsAsync(CustomerByFilterItemsQuery request);
    ValueTask<ICollection<CustomerResponse>?> SearchByItemsAsync(string request);
    Task<CustomerResponse?> ChangeStatusCustomerByIdAsync(Status status, Ulid customerId);
    Task<CustomerResponse?> CreateCustomerAsync(CreateCustomerCommand request);
    Task<CustomerResponse?> UpdateCustomerAsync(UpdateCustomerCommand request);
    Task<CustomerResponse?> DeleteCustomerAsync(Ulid customerId);
}