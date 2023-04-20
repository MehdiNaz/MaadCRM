namespace Application.Interfaces.Customers;

public interface ICustomersEmailAddressRepository
{
    ValueTask<ICollection<CustomersEmailAddress?>> GetAllEmailAddressesAsync();
    ValueTask<CustomersEmailAddress?> GetEmailAddressByIdAsync(Ulid emailAddressId);
    ValueTask<CustomersEmailAddress?> ChangeStatusEmailAddressByIdAsync(ChangeStatusCustomersEmailAddressCommand request);
    ValueTask<CustomersEmailAddress?> CreateEmailAddressAsync(CreateCustomersEmailAddressCommand request);
    ValueTask<CustomersEmailAddress?> UpdateEmailAddressAsync(UpdateCustomersEmailAddressCommand request);
    ValueTask<CustomersEmailAddress?> DeleteEmailAddressAsync(DeleteCustomersEmailAddressCommand request);
}
