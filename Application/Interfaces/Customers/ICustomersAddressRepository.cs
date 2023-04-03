namespace Application.Interfaces.Customers;

public interface ICustomersAddressRepository
{
    ValueTask<ICollection<CustomersAddress?>> GetAllAddressesAsync();
    ValueTask<CustomersAddress?> GetAddressByIdAsync(Ulid customersAddressId);
    ValueTask<CustomersAddress?> CreateAddressAsync(CustomersAddress? entity);
    ValueTask<CustomersAddress?> UpdateAddressAsync(CustomersAddress entity, Ulid customersAddressId);
    ValueTask<CustomersAddress?> DeleteAddressAsync(Ulid customersAddressId);
}