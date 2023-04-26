namespace Application.Interfaces.Customers;

public interface ICustomersAddressRepository
{
    ValueTask<ICollection<CustomerAddress?>> GetAllAddressesAsync(Ulid customerId);
    ValueTask<CustomerAddress?> GetAddressByIdAsync(Ulid customersAddressId);
    ValueTask<CustomerAddress?> ChangeStatusAddressByIdAsync(ChangeStatusCustomersAddressCommand request);
    ValueTask<CustomerAddress?> CreateAddressAsync(CreateCustomersAddressCommand request);
    ValueTask<CustomerAddress?> UpdateAddressAsync(UpdateCustomersAddressCommand request);
    ValueTask<CustomerAddress?> DeleteAddressAsync(Ulid id);
}