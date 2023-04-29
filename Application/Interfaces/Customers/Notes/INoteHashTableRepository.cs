namespace Application.Interfaces.Customers.Notes;

public interface INoteHashTableRepository
{
    ValueTask<Result<ICollection<CustomerNoteHashTableResponse>>> GetAllNoteHashTablesAsync(Ulid customerId);
    ValueTask<Result<CustomerNoteHashTableResponse>> GetNoteHashTableByIdAsync(Ulid noteHashTableId);
    ValueTask<Result<CustomerNoteHashTableResponse>> ChangeStatusNoteHashTableByIdAsync(ChangeStatusNoteHashTableCommand request);
    ValueTask<Result<CustomerNoteHashTableResponse>> CreateNoteHashTableAsync(CreateNoteHashTableCommand request);
    ValueTask<Result<CustomerNoteHashTableResponse>> UpdateNoteHashTableAsync(UpdateNoteHashTableCommand request);
    ValueTask<Result<CustomerNoteHashTableResponse>> DeleteNoteHashTableAsync(Ulid id);
}