namespace Application.Interfaces.Customers;

public interface ICustomerActivityRepository
{
    ValueTask<ICollection<CustomerActivity?>> GetAllCustomerActivitiesAsync(Ulid customerId);
    ValueTask<CustomerActivity?> GetCustomerActivityByIdAsync(Ulid customerActivityId);
    ValueTask<CustomerActivity?> ChangeStatusCustomerActivityByIdAsync(Status status, Ulid customerActivityId);
    ValueTask<CustomerActivity?> CreateCustomerActivityAsync(CustomerActivity? entity);
    ValueTask<CustomerActivity?> UpdateCustomerActivityAsync(CustomerActivity entity);
    ValueTask<CustomerActivity?> DeleteCustomerActivityAsync(Ulid customerActivityId);
}