namespace Application.Interfaces.Customers.PeyGiry;

public interface ICustomerPeyGiryRepository
{
    ValueTask<Result<ICollection<CustomerPeyGiryResponse>>> GetAllCustomerPeyGiriesAsync(Ulid customerId);
    ValueTask<Result<CustomerPeyGiry>> GetCustomerPeyGiryByIdAsync(Ulid customerPeyGiryId);
    ValueTask<Result<CustomerPeyGiry>> ChangeStatusCustomerPeyGiryByIdAsync(ChangeStatusCustomerPeyGiryCommand request);
    ValueTask<Result<CustomerPeyGiry>> CreateCustomerPeyGiryAsync(CreateCustomerPeyGiryCommand request);
    ValueTask<Result<CustomerPeyGiry>> UpdateCustomerPeyGiryAsync(UpdateCustomerPeyGiryCommand request);
    ValueTask<Result<CustomerPeyGiry>> DeleteCustomerPeyGiryAsync(DeleteCustomerPeyGiryCommand request);
}