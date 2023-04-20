namespace Application.Interfaces.Customers.PeyGiry;

public interface ICustomerPeyGiryRepository
{
    ValueTask<ICollection<CustomerPeyGiryResponse>> GetAllCustomerPeyGiriesAsync(Ulid customerId);
    ValueTask<CustomerPeyGiry?> GetCustomerPeyGiryByIdAsync(Ulid customerPeyGiryId);
    ValueTask<CustomerPeyGiry?> ChangeStatusCustomerPeyGiryByIdAsync(ChangeStatusCustomerPeyGiryCommand request);
    ValueTask<CustomerPeyGiry?> CreateCustomerPeyGiryAsync(CreateCustomerPeyGiryCommand request);
    ValueTask<CustomerPeyGiry?> UpdateCustomerPeyGiryAsync(UpdateCustomerPeyGiryCommand request);
    ValueTask<CustomerPeyGiry?> DeleteCustomerPeyGiryAsync(DeleteCustomerPeyGiryCommand request);
}