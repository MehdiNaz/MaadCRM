namespace Application.Interfaces.Customers.Notes;

public interface INoteHashTableRepository
{
    ValueTask<ICollection<NoteHashTable?>> GetAllNoteHashTablesAsync(Ulid customerId);
    ValueTask<NoteHashTable?> GetNoteHashTableByIdAsync(Ulid noteHashTableId);
    ValueTask<NoteHashTable?> ChangeStatusNoteHashTableByIdAsync(Status status, Ulid noteHashTableId);
    ValueTask<NoteHashTable?> CreateNoteHashTableAsync(CreateNoteHashTableCommand entity);
    ValueTask<NoteHashTable?> UpdateNoteHashTableAsync(UpdateNoteHashTableCommand entity);
    ValueTask<NoteHashTable?> DeleteNoteHashTableAsync(Ulid noteHashTableId);
}