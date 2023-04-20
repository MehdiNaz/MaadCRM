namespace Application.Interfaces.Customers;

public interface ICustomersAddressRepository
{
    ValueTask<ICollection<CustomersAddress?>> GetAllAddressesAsync(Ulid customerId);
    ValueTask<CustomersAddress?> GetAddressByIdAsync(Ulid customersAddressId);
    ValueTask<CustomersAddress?> ChangeStatusAddressByIdAsync(ChangeStatusCustomersAddressCommand request);
    ValueTask<CustomersAddress?> CreateAddressAsync(CreateCustomersAddressCommand request);
    ValueTask<CustomersAddress?> UpdateAddressAsync(UpdateCustomersAddressCommand request);
    ValueTask<CustomersAddress?> DeleteAddressAsync(DeleteCustomersAddressCommand request);
}