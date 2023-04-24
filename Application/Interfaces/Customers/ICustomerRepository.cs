namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    ValueTask<Result<ICollection<CustomerResponse>>> GetAllCustomersAsync(string userId);
    ValueTask<Result<CustomerResponse>> GetCustomerByIdAsync(Ulid customerId);
    ValueTask<Result<ICollection<CustomerResponse>>> FilterByItemsAsync(CustomerByFilterItemsQuery request);
    ValueTask<Result<ICollection<CustomerResponse>>> SearchByItemsAsync(string request);
    ValueTask<Result<CustomerResponse>> ChangeStatusCustomerByIdAsync(ChangeStatusCustomerCommand request);
    ValueTask<Result<CustomerResponse>> CreateCustomerAsync(CreateCustomerCommand request);
    ValueTask<Result<CustomerResponse>> UpdateCustomerAsync(UpdateCustomerCommand request);
    ValueTask<Result<CustomerResponse>> DeleteCustomerAsync(Ulid customerId);
}