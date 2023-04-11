namespace Application.Interfaces.Customers.Notes;

public interface ICustomerNoteRepository
{
    ValueTask<ICollection<CustomerNote?>> GetAllCustomerNotesAsync(Ulid customerId);
    ValueTask<CustomerNote?> GetCustomerNoteByIdAsync(Ulid customerNoteId);
    ValueTask<CustomerNote?> CreateCustomerNoteAsync(CustomerNote? entity);
    ValueTask<CustomerNote?> UpdateCustomerNoteAsync(CustomerNote entity);
    ValueTask<CustomerNote?> DeleteCustomerNoteAsync(Ulid customerNoteId);
}