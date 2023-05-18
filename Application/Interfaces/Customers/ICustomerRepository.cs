namespace Application.Interfaces.Customers;

public interface ICustomerRepository
{
    ValueTask<Result<ICollection<CustomerResponse>>> GetAllCustomersAsync(string userId);
    ValueTask<Result<CustomerResponse>> GetCustomerByIdAsync(Ulid customerId, string userId);
    ValueTask<Result<int>> ShowBelghovehCustomersCountAsync();
    ValueTask<Result<int>> ShowBelFelCustomersCountAsync();
    ValueTask<Result<int>> ShowRazyCustomersCountAsync();
    ValueTask<Result<int>> ShowNaRazyCustomersCountAsync();
    ValueTask<Result<int>> ShowDarHalePeyGiryCustomersCountAsync();
    ValueTask<Result<int>> ShowVafadarCustomersCountAsync();
    ValueTask<Result<int>> ShowAllCustomersCountAsync();
    ValueTask<Result<CustomerDashboardResponse>> FilterByItemsAsync(CustomerByFilterItemsQuery request);
    ValueTask<Result<CustomerDashboardResponse>> SearchByItemsAsync(string request, string userId);
    ValueTask<Result<CustomerResponse>> ChangeStatusCustomerByIdAsync(ChangeStatusCustomerCommand request);
    ValueTask<Result<CustomerResponse>> ChangeStateCustomerByIdAsync(ChangeStateCustomerCommand request);
    ValueTask<Result<CustomerResponse>> CreateCustomerAsync(CreateCustomerCommand request);
    ValueTask<Result<CustomerResponse>> UpdateCustomerAsync(UpdateCustomerCommand request);
    ValueTask<string> DeleteCustomerAsync(Ulid customerId);
}