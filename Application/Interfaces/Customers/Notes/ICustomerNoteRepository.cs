﻿namespace Application.Interfaces.Customers.Notes;

public interface ICustomerNoteRepository
{
    ValueTask<ICollection<CustomerNote?>> GetAllCustomerNotesAsync();
    ValueTask<CustomerNote?> GetCustomerNoteByIdAsync(Ulid customerNoteId);
    ValueTask<CustomerNote?> CreateCustomerNoteAsync(CustomerNote? entity);
    ValueTask<CustomerNote?> UpdateCustomerNoteAsync(CustomerNote entity, Ulid customerNoteId);
    ValueTask<CustomerNote?> DeleteCustomerNoteAsync(Ulid customerNoteId);
}