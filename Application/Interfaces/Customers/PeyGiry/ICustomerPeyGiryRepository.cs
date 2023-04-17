﻿namespace Application.Interfaces.Customers.PeyGiry;

public interface ICustomerPeyGiryRepository
{
    ValueTask<ICollection<CustomerPeyGiryResponse>> GetAllCustomerPeyGiriesAsync(Ulid customerId);
    ValueTask<CustomerPeyGiry?> GetCustomerPeyGiryByIdAsync(Ulid customerPeyGiryId);
    ValueTask<CustomerPeyGiry?> ChangeStatusCustomerPeyGiryByIdAsync(Status status, Ulid customerPeyGiryId);
    ValueTask<CustomerPeyGiry?> CreateCustomerPeyGiryAsync(CustomerPeyGiry? entity);
    ValueTask<CustomerPeyGiry?> UpdateCustomerPeyGiryAsync(CustomerPeyGiry entity);
    ValueTask<CustomerPeyGiry?> DeleteCustomerPeyGiryAsync(Ulid customerPeyGiryId);
}