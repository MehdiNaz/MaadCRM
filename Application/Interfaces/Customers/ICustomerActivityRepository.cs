namespace Application.Interfaces.Customers;

public interface ICustomerActivityRepository
{
    ValueTask<ICollection<CustomerActivity?>> GetAllCustomerActivitiesAsync(Ulid customerId);
    ValueTask<CustomerActivity?> GetCustomerActivityByIdAsync(Ulid customerActivityId);
    ValueTask<CustomerActivity?> ChangeStatusCustomerActivityByIdAsync(ChangeStatusCustomerActivityCommand request);
    ValueTask<CustomerActivity?> CreateCustomerActivityAsync(CreateCustomerActivityCommand request);
    ValueTask<CustomerActivity?> UpdateCustomerActivityAsync(UpdateCustomerActivityCommand request);
    ValueTask<CustomerActivity?> DeleteCustomerActivityAsync(DeleteCustomerActivityCommand request);
}