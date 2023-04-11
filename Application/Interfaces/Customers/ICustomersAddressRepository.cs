namespace Application.Interfaces.Customers;

public interface ICustomersAddressRepository
{
    ValueTask<ICollection<CustomersAddress?>> GetAllAddressesAsync(Ulid customerId);
    ValueTask<CustomersAddress?> GetAddressByIdAsync(Ulid customersAddressId);
    ValueTask<CustomersAddress?> CreateAddressAsync(CustomersAddress? entity);
    ValueTask<CustomersAddress?> UpdateAddressAsync(CustomersAddress entity);
    ValueTask<CustomersAddress?> DeleteAddressAsync(Ulid customersAddressId);
}