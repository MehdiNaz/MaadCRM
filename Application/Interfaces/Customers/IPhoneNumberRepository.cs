namespace Application.Interfaces.Customers;

public interface IPhoneNumberRepository
{
    ValueTask<ICollection<PhoneNumber?>> GetAllPhoneNumbersAsync();
    ValueTask<PhoneNumber?> GetPhoneNumberByIdAsync(Ulid phoneNumberId);
    ValueTask<PhoneNumber?> CreatePhoneNumberAsync(PhoneNumber? entity);
    ValueTask<PhoneNumber?> UpdatePhoneNumberAsync(PhoneNumber entity, Ulid phoneNumberId);
    ValueTask<PhoneNumber?> DeletePhoneNumberAsync(Ulid phoneNumberId);
}