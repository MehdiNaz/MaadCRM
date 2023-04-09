﻿namespace Application.Interfaces.Customers;

public interface ICustomerCategoryRepository
{
    ValueTask<ICollection<CustomerCategory?>> GetAllCustomerCategoryAsync();
    ValueTask<CustomerCategory?> GetCustomerCategoryByIdAsync(Ulid CustomerCategoryId);
    ValueTask<CustomerCategory?> CreateCustomerCategoryAsync(CustomerCategory? entity);
    ValueTask<CustomerCategory?> UpdateCustomerCategoryAsync(CustomerCategory entity);
    ValueTask<CustomerCategory?> DeleteCusCustomerAsync(Ulid CustomerCategoryId);
}