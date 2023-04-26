namespace Application.Interfaces.Customers.Notes;

public interface INoteHashTableRepository
{
    ValueTask<ICollection<CustomerNoteHashTable?>> GetAllNoteHashTablesAsync(Ulid customerId);
    ValueTask<CustomerNoteHashTable?> GetNoteHashTableByIdAsync(Ulid noteHashTableId);
    ValueTask<CustomerNoteHashTable?> ChangeStatusNoteHashTableByIdAsync(ChangeStatusNoteHashTableCommand request);
    ValueTask<CustomerNoteHashTable?> CreateNoteHashTableAsync(CreateNoteHashTableCommand request);
    ValueTask<CustomerNoteHashTable?> UpdateNoteHashTableAsync(UpdateNoteHashTableCommand request);
    ValueTask<CustomerNoteHashTable?> DeleteNoteHashTableAsync(Ulid id);
}