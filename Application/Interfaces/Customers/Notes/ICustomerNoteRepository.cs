namespace Application.Interfaces.Customers.Notes;

public interface ICustomerNoteRepository
{
    ValueTask<ICollection<CustomerNote?>> GetAllCustomerNotesAsync(Ulid customerId);
    ValueTask<CustomerNote?> GetCustomerNoteByIdAsync(Ulid customerNoteId);
    ValueTask<CustomerNote?> ChangeStatusCustomerNoteByIdAsync(ChangeStatusCustomerNoteCommand request);
    ValueTask<CustomerNote?> CreateCustomerNoteAsync(CreateCustomerNoteCommand request);
    ValueTask<CustomerNote?> UpdateCustomerNoteAsync(UpdateCustomerNoteCommand request);
    ValueTask<CustomerNote?> DeleteCustomerNoteAsync(DeleteCustomerNoteCommand request);
}