namespace Application.Interfaces.Customers.PeyGiry;

public interface ICustomerPeyGiryRepository
{
    ValueTask<ICollection<CustomerPeyGiry?>> GetAllCustomerPeyGiriessAsync();
    ValueTask<CustomerPeyGiry?> GetCustomerPeyGiryByIdAsync(Ulid customerPeyGiryId);
    ValueTask<CustomerPeyGiry?> CreateCustomerPeyGiryAsync(CustomerPeyGiry? entity);
    ValueTask<CustomerPeyGiry?> UpdateCustomerPeyGiryAsync(CustomerPeyGiry entity, Ulid customerPeyGiryId);
    ValueTask<CustomerPeyGiry?> DeleteCustomerPeyGiryAsync(Ulid customerPeyGiryId);
}