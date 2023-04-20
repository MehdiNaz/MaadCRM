namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    ValueTask<ICollection<CustomerResponse>> GetAllCustomersAsync(string userId);
    ValueTask<CustomerResponse> GetCustomerByIdAsync(Ulid customerId);
    ValueTask<ICollection<CustomerResponse>?> FilterByItemsAsync(CustomerByFilterItemsQuery request);
    ValueTask<ICollection<CustomerResponse>?> SearchByItemsAsync(string request);
    ValueTask<CustomerResponse?> ChangeStatusCustomerByIdAsync(ChangeStatusCustomerCommand request);
    ValueTask<CustomerResponse?> CreateCustomerAsync(CreateCustomerCommand request);
    ValueTask<CustomerResponse?> UpdateCustomerAsync(UpdateCustomerCommand request);
    ValueTask<CustomerResponse?> DeleteCustomerAsync(Ulid customerId);
}