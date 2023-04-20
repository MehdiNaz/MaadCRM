namespace DataAccess.Repositories.Customers.Note;

public class NoteHashTableRepository : INoteHashTableRepository
{
    private readonly MaadContext _context;

    public NoteHashTableRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<NoteHashTable?>> GetAllNoteHashTablesAsync(Ulid customerId)
        => await _context.NoteHashTables.Where(x => x.NoteHashTagStatus == Status.Show).ToListAsync();

    public async ValueTask<NoteHashTable?> GetNoteHashTableByIdAsync(Ulid noteHashTableId)
        => await _context.NoteHashTables.SingleOrDefaultAsync(x => x.Id == noteHashTableId && x.NoteHashTagStatus == Status.Show);

    public async ValueTask<NoteHashTable?> ChangeStatusNoteHashTableByIdAsync(ChangeStatusNoteHashTableCommand request)
    {
        try
        {
            var item = await _context.NoteHashTables!.FindAsync(request.Id);
            if (item is null) return null;
            item.NoteHashTagStatus = request.NoteHashTagStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteHashTable?> CreateNoteHashTableAsync(CreateNoteHashTableCommand entity)
    {
        try
        {
            NoteHashTable noteHashTable = new()
            {
                Title = entity.Title,
                BusinessId = entity.BusinessId
            };
            await _context.NoteHashTables!.AddAsync(noteHashTable);
            await _context.SaveChangesAsync();
            return noteHashTable;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteHashTable?> UpdateNoteHashTableAsync(UpdateNoteHashTableCommand entity)
    {
        try
        {
            NoteHashTable noteHashTable = new()
            {
                Id = entity.Id,
                Title = entity.Title,
                BusinessId = entity.BusinessId
            };
            _context.Update(noteHashTable);
            await _context.SaveChangesAsync();
            return noteHashTable;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteHashTable?> DeleteNoteHashTableAsync(DeleteNoteHashTableCommand request)
    {
        try
        {
            var noteHashTable = await GetNoteHashTableByIdAsync(request.Id);
            noteHashTable!.NoteHashTagStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return noteHashTable;
        }
        catch
        {
            return null;
        }
    }
}