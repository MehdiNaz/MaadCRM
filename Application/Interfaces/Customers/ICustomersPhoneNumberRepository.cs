namespace Application.Interfaces.Customers;

public interface ICustomersPhoneNumberRepository
{
    ValueTask<ICollection<CustomersPhoneNumber?>> GetAllPhoneNumbersAsync();
    ValueTask<CustomersPhoneNumber?> GetPhoneNumberByIdAsync(Ulid phoneNumberId);
    ValueTask<CustomersPhoneNumber?> ChangeStatusPhoneNumberByIdAsync(ChangeStatusCustomerPhoneNumberCommand request);
    ValueTask<CustomersPhoneNumber?> CreatePhoneNumberAsync(CreateCustomerPhoneNumberCommand request);
    ValueTask<CustomersPhoneNumber?> UpdatePhoneNumberAsync(UpdateCustomerPhoneNumberCommand request);
    ValueTask<CustomersPhoneNumber?> DeletePhoneNumberAsync(Ulid id);
}