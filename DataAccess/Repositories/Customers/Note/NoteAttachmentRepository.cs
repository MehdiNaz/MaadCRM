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
        => await _context.NoteAttachments.FirstOrDefaultAsync(x => x.Id == noteAttachmentId && x.NoteAttachmentStatus == Status.Show);

    public async ValueTask<NoteAttachment?> ChangeStatusNoteAttachmentByIdAsync(ChangeStatusNoteAttachmentCommand request)
    {
        try
        {
            var item = await _context.NoteAttachments!.FindAsync(request.Id);
            if (item is null) return null;
            item.NoteAttachmentStatus = request.NoteAttachmentStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteAttachment?> CreateNoteAttachmentAsync(CreateNoteAttachmentCommand request)
    {
        try
        {
            NoteAttachment item = new()
            {
                CustomerNoteId = request.CustomerNoteId,
                FileName = request.FileName,
                Extenstion = request.Extenstion
            };
            await _context.NoteAttachments!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<NoteAttachment?> UpdateNoteAttachmentAsync(UpdateNoteAttachmentCommand request)
    {
        try
        {
            NoteAttachment item = new()
            {
                Id = request.Id,
                CustomerNoteId = request.CustomerNoteId,
                FileName = request.FileName,
                Extenstion = request.Extenstion
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

    public async ValueTask<NoteAttachment?> DeleteNoteAttachmentAsync(DeleteNoteAttachmentCommand request)
    {
        try
        {
            var noteAttachment = await GetNoteAttachmentByIdAsync(request.Id);
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