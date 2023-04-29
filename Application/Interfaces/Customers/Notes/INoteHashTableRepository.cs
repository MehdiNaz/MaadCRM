namespace Application.Interfaces.Customers.Notes;

public interface INoteHashTableRepository
{
    ValueTask<Result<ICollection<CustomerNoteHashTable>>> GetAllNoteHashTablesAsync(Ulid customerId);
    ValueTask<Result<CustomerNoteHashTable>> GetNoteHashTableByIdAsync(Ulid noteHashTableId);
    ValueTask<Result<CustomerNoteHashTable>> ChangeStatusNoteHashTableByIdAsync(ChangeStatusNoteHashTableCommand request);
    ValueTask<Result<CustomerNoteHashTable>> CreateNoteHashTableAsync(CreateNoteHashTableCommand request);
    ValueTask<Result<CustomerNoteHashTable>> UpdateNoteHashTableAsync(UpdateNoteHashTableCommand request);
    ValueTask<Result<CustomerNoteHashTable>> DeleteNoteHashTableAsync(Ulid id);
}