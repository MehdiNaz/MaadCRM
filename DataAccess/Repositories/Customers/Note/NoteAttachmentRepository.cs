namespace DataAccess.Repositories.Customers.Note;

public class NoteAttachmentRepository : INoteAttachmentRepository
{
    private readonly MaadContext _context;

    public NoteAttachmentRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<NoteAttachment?>> GetAllNoteAttachmentsAsync()
        => await _context.NoteAttachments.Where(x => x.NoteAttachmentStatus == Status.Show).ToListAsync();

    public async ValueTask<NoteAttachment?> GetNoteAttachmentByIdAsync(Ulid noteAttachmentId)
        => await _context.NoteAttachments.FirstOrDefaultAsync(x => x.NoteAttachmentId == noteAttachmentId && x.NoteAttachmentStatus == Status.Show);

    public async ValueTask<NoteAttachment?> ChangeStatusNoteAttachmentByIdAsync(Status status, Ulid noteAttachmentId)
    {
        try
        {
            var item = await _context.NoteAttachments!.FindAsync(noteAttachmentId);
            if (item is null) return null;
            item.NoteAttachmentStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteAttachment?> CreateNoteAttachmentAsync(NoteAttachment? entity)
    {
        try
        {
            await _context.NoteAttachments!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteAttachment?> UpdateNoteAttachmentAsync(NoteAttachment entity)
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

    public async ValueTask<NoteAttachment?> DeleteNoteAttachmentAsync(Ulid noteAttachmentId)
    {
        try
        {
            var noteAttachment = await GetNoteAttachmentByIdAsync(noteAttachmentId);
            noteAttachment!.NoteAttachmentStatus = Status.Show;
            await _context.SaveChangesAsync();
            return noteAttachment;
        }
        catch
        {
            return null;
        }
    }
}