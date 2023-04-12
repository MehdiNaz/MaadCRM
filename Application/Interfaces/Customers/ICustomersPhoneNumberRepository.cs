namespace Application.Interfaces.Customers;

public interface ICustomersPhoneNumberRepository
{
    ValueTask<ICollection<CustomersPhoneNumber?>> GetAllPhoneNumbersAsync();
    ValueTask<CustomersPhoneNumber?> GetPhoneNumberByIdAsync(Ulid phoneNumberId);
    ValueTask<CustomersPhoneNumber?> ChangeStatusPhoneNumberByIdAsync(Status status, Ulid phoneNumberId);
    ValueTask<CustomersPhoneNumber?> CreatePhoneNumberAsync(CustomersPhoneNumber? entity);
    ValueTask<CustomersPhoneNumber?> UpdatePhoneNumberAsync(CustomersPhoneNumber entity, Ulid phoneNumberId);
    ValueTask<CustomersPhoneNumber?> DeletePhoneNumberAsync(Ulid phoneNumberId);
}