namespace DataAccess.Repositories.Customers.Note;

public class NoteHashTableRepository : INoteHashTableRepository
{
    private readonly MaadContext _context;

    public NoteHashTableRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerNoteHashTable?>> GetAllNoteHashTablesAsync(Ulid customerId)
        => await _context.NoteHashTables.Where(x => x.NoteHashTagStatus == Status.Show).ToListAsync();

    public async ValueTask<CustomerNoteHashTable?> GetNoteHashTableByIdAsync(Ulid noteHashTableId)
        => await _context.NoteHashTables.SingleOrDefaultAsync(x => x.Id == noteHashTableId && x.NoteHashTagStatus == Status.Show);

    public async ValueTask<CustomerNoteHashTable?> ChangeStatusNoteHashTableByIdAsync(ChangeStatusNoteHashTableCommand request)
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

    public async ValueTask<CustomerNoteHashTable?> CreateNoteHashTableAsync(CreateNoteHashTableCommand entity)
    {
        try
        {
            CustomerNoteHashTable noteHashTable = new()
            {
                Title = entity.Title,
                IdBusiness = entity.BusinessId
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

    public async ValueTask<CustomerNoteHashTable?> UpdateNoteHashTableAsync(UpdateNoteHashTableCommand entity)
    {
        try
        {
            CustomerNoteHashTable noteHashTable = new()
            {
                Id = entity.Id,
                Title = entity.Title,
                IdBusiness = entity.BusinessId
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

    public async ValueTask<CustomerNoteHashTable?> DeleteNoteHashTableAsync(DeleteNoteHashTableCommand request)
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