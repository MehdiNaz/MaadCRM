namespace Application.Interfaces.Customers.Notes;

public interface ICustomerNoteRepository
{
    ValueTask<Result<ICollection<CustomerNoteResponse>>> GetAllCustomerNotesAsync(Ulid customerId);
    ValueTask<Result<CustomerNoteResponse>> GetCustomerNoteByIdAsync(Ulid customerNoteId);
    ValueTask<Result<CustomerNote>> ChangeStatusCustomerNoteByIdAsync(ChangeStatusCustomerNoteCommand request);
    ValueTask<Result<CustomerNote>> CreateCustomerNoteAsync(CreateCustomerNoteCommand request);
    ValueTask<Result<CustomerNote>> UpdateCustomerNoteAsync(UpdateCustomerNoteCommand request);
    ValueTask<Result<CustomerNote>> DeleteCustomerNoteAsync(Ulid id);
}