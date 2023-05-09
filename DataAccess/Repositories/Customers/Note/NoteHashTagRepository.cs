namespace DataAccess.Repositories.Customers.Note;

public class NoteHashTagRepository : INoteHashTagRepository
{
    private readonly MaadContext _context;

    public NoteHashTagRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerNoteHashTag?>> GetAllNoteHashTagsAsync()
        => await _context.NoteHashTags.Where(x => x.StatusTypeNoteHashTag == StatusType.Show).ToListAsync();

    public async ValueTask<CustomerNoteHashTag?> GetNoteHashTagByIdAsync(Ulid noteHashTagId)
    {
        // TODO: Fix x.IdCustomerNote == noteHashTagId
        return await _context.NoteHashTags.FirstOrDefaultAsync(x =>
            x.IdNoteHashTable == noteHashTagId && x.IdCustomerNote == noteHashTagId &&
            x.StatusTypeNoteHashTag == StatusType.Show);
    }

    public async ValueTask<CustomerNoteHashTag?> ChangeStatusNoteHashTagByIdAsync(ChangeStatusNoteHashTagCommand request)
    {
        try
        {
            var item = await _context.NoteHashTags!.FindAsync(request.Id);
            if (item is null) return null;
            item.StatusTypeNoteHashTag = request.NoteHashTagStatusType;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerNoteHashTag?> CreateNoteHashTagAsync(CreateNoteHashTagCommand request)
    {
        try
        {
            CustomerNoteHashTag item = new()
            {
                IdCustomerNote = request.CustomerNoteId,
                IdNoteHashTable = request.NoteHashTableId
            };
            await _context.NoteHashTags!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerNoteHashTag?> UpdateNoteHashTagAsync(UpdateNoteHashTagCommand request)
    {
        try
        {
            CustomerNoteHashTag item = await _context.NoteHashTags.FindAsync(request.Id);
            item.IdCustomerNote = request.CustomerNoteId;
            item.IdNoteHashTable = request.NoteHashTableId;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerNoteHashTag?> DeleteNoteHashTagAsync(Ulid id)
    {
        try
        {
            var noteHashTag = await _context.NoteHashTags.FindAsync(id);
            noteHashTag!.StatusTypeNoteHashTag = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return noteHashTag;
        }
        catch
        {
            return null;
        }
    }
}