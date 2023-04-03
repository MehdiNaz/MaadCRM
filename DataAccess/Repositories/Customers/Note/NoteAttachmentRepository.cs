namespace DataAccess.Repositories.Customers.Note;

public class NoteAttachmentRepository : INoteAttachmentRepository
{
    private readonly MaadContext _context;

    public NoteAttachmentRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<NoteAttachment?>> GetAllNoteAttachmentsAsync()
        => (await _context.NoteAttachments!.ToListAsync()).Where(x => x.IsDeleted == Status.NotDeleted).ToList()!;

    public async ValueTask<NoteAttachment?> GetNoteAttachmentByIdAsync(Ulid noteAttachmentId)
        => await _context.NoteAttachments!.FindAsync(noteAttachmentId);


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

    public async ValueTask<NoteAttachment?> UpdateNoteAttachmentAsync(NoteAttachment entity, Ulid noteAttachmentId)
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
            noteAttachment!.IsDeleted = Status.Deleted;
            await _context.SaveChangesAsync();
            return noteAttachment;
        }
        catch
        {
            return null;
        }
    }
}