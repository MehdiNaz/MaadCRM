namespace Application.Interfaces.Customers.Notes;

public interface ICustomerNoteRepository
{
    ValueTask<Result<ICollection<CustomerNoteResponse>>> GetAllCustomerNotesAsync(Ulid customerId);
    ValueTask<Result<CustomerNoteResponse>> GetCustomerNoteByIdAsync(Ulid customerNoteId);
    ValueTask<Result<CustomerNoteResponse>> ChangeStatusCustomerNoteByIdAsync(ChangeStatusCustomerNoteCommand request);
    ValueTask<Result<CustomerNoteResponse>> CreateCustomerNoteAsync(CreateCustomerNoteCommand request);
    ValueTask<Result<CustomerNoteResponse>> UpdateCustomerNoteAsync(UpdateCustomerNoteCommand request);
    ValueTask<Result<CustomerNoteResponse>> DeleteCustomerNoteAsync(Ulid id);
}