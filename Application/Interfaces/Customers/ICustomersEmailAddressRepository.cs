namespace Application.Interfaces.Customers;

public interface ICustomersEmailAddressRepository
{
    ValueTask<ICollection<CustomersEmailAddress?>> GetAllEmailAddressesAsync();
    ValueTask<CustomersEmailAddress?> GetEmailAddressByIdAsync(Ulid emailAddressId);
    ValueTask<CustomersEmailAddress?> ChangeStatusEmailAddressByIdAsync(Status status, Ulid emailAddressId);
    ValueTask<CustomersEmailAddress?> CreateEmailAddressAsync(CustomersEmailAddress? entity);
    ValueTask<CustomersEmailAddress?> UpdateEmailAddressAsync(CustomersEmailAddress entity, Ulid emailAddressId);
    ValueTask<CustomersEmailAddress?> DeleteEmailAddressAsync(Ulid emailAddressId);
}
