namespace Application.Interfaces.Customers.Notes;

public interface INoteHashTableRepository
{
    ValueTask<ICollection<NoteHashTable?>> GetAllNoteHashTablesAsync(Ulid customerId);
    ValueTask<NoteHashTable?> GetNoteHashTableByIdAsync(Ulid noteHashTableId);
    ValueTask<NoteHashTable?> ChangeStatusNoteHashTableByIdAsync(ChangeStatusNoteHashTableCommand request);
    ValueTask<NoteHashTable?> CreateNoteHashTableAsync(CreateNoteHashTableCommand request);
    ValueTask<NoteHashTable?> UpdateNoteHashTableAsync(UpdateNoteHashTableCommand request);
    ValueTask<NoteHashTable?> DeleteNoteHashTableAsync(DeleteNoteHashTableCommand request);
}