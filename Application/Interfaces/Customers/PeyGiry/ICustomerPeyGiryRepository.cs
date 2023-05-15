namespace Application.Interfaces.Customers.PeyGiry;

public interface ICustomerPeyGiryRepository
{
    ValueTask<Result<ICollection<CustomerPeyGiryResponse>>> GetAllCustomerPeyGiriesAsync(Ulid customerId);
    ValueTask<Result<CustomerPeyGiryResponse>> GetCustomerPeyGiryByIdAsync(Ulid customerPeyGiryId);
    ValueTask<Result<CustomerPeyGiryResponse>> ChangeStatusCustomerPeyGiryByIdAsync(ChangeStatusCustomerPeyGiryCommand request);
    ValueTask<Result<CustomerPeyGiryResponse>> CreateCustomerPeyGiryAsync(CreateCustomerPeyGiryCommand request);
    ValueTask<Result<CustomerPeyGiryResponse>> UpdateCustomerPeyGiryAsync(UpdateCustomerPeyGiryCommand request);
    ValueTask<Result<CustomerPeyGiryResponse>> DeleteCustomerPeyGiryAsync(Ulid id);
}