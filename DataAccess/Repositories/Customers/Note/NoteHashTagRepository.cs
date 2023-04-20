namespace DataAccess.Repositories.Customers.Note;

public class NoteHashTagRepository : INoteHashTagRepository
{
    private readonly MaadContext _context;

    public NoteHashTagRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<NoteHashTag?>> GetAllNoteHashTagsAsync()
        => await _context.NoteHashTags.Where(x => x.NoteHashTagStatus == Status.Show).ToListAsync();

    public async ValueTask<NoteHashTag?> GetNoteHashTagByIdAsync(Ulid noteHashTagId)
        => await _context.NoteHashTags.FirstOrDefaultAsync(x => x.Id == noteHashTagId && x.NoteHashTagStatus == Status.Show);

    public async ValueTask<NoteHashTag?> ChangeStatusNoteHashTagByIdAsync(ChangeStatusNoteHashTagCommand request)
    {
        try
        {
            var item = await _context.NoteHashTags!.FindAsync(request.Id);
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

    public async ValueTask<NoteHashTag?> CreateNoteHashTagAsync(CreateNoteHashTagCommand request)
    {
        try
        {
            NoteHashTag item = new()
            {
                CustomerNoteId = request.CustomerNoteId,
                NoteHashTableId = request.NoteHashTableId
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

    public async ValueTask<NoteHashTag?> UpdateNoteHashTagAsync(UpdateNoteHashTagCommand request)
    {
        try
        {
            NoteHashTag item = new()
            {
                Id = request.Id,
                CustomerNoteId = request.CustomerNoteId,
                NoteHashTableId = request.NoteHashTableId
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteHashTag?> DeleteNoteHashTagAsync(DeleteNoteHashTagCommand request)
    {
        try
        {
            var noteHashTag = await GetNoteHashTagByIdAsync(request.Id);
            noteHashTag!.NoteHashTagStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return noteHashTag;
        }
        catch
        {
            return null;
        }
    }
}