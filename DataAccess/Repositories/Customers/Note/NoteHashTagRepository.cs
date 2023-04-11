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
        => await _context.NoteHashTags.FindAsync(noteHashTagId);

    public async ValueTask<NoteHashTag?> CreateNoteHashTagAsync(NoteHashTag? entity)
    {
        try
        {
            await _context.NoteHashTags!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteHashTag?> UpdateNoteHashTagAsync(NoteHashTag entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteHashTag?> DeleteNoteHashTagAsync(Ulid noteHashTagId)
    {
        try
        {
            var noteHashTag = await GetNoteHashTagByIdAsync(noteHashTagId);
            noteHashTag!.NoteHashTagStatus = Status.Show;
            await _context.SaveChangesAsync();
            return noteHashTag;
        }
        catch
        {
            return null;
        }
    }
}