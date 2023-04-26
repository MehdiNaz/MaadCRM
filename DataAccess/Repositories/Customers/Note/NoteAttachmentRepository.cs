﻿namespace DataAccess.Repositories.Customers.Note;

public class NoteAttachmentRepository : INoteAttachmentRepository
{
    private readonly MaadContext _context;

    public NoteAttachmentRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerNoteAttachment?>> GetAllNoteAttachmentsAsync()
        => await _context.NoteAttachments.Where(x => x.NoteAttachmentStatus == Status.Show).ToListAsync();

    public async ValueTask<CustomerNoteAttachment?> GetNoteAttachmentByIdAsync(Ulid noteAttachmentId)
        => await _context.NoteAttachments.FirstOrDefaultAsync(x => x.Id == noteAttachmentId && x.NoteAttachmentStatus == Status.Show);

    public async ValueTask<CustomerNoteAttachment?> ChangeStatusNoteAttachmentByIdAsync(ChangeStatusNoteAttachmentCommand request)
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

    public async ValueTask<CustomerNoteAttachment?> CreateNoteAttachmentAsync(CreateNoteAttachmentCommand request)
    {
        try
        {
            CustomerNoteAttachment item = new()
            {
                IdCustomerNote = request.CustomerNoteId,
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

    public async ValueTask<CustomerNoteAttachment?> UpdateNoteAttachmentAsync(UpdateNoteAttachmentCommand request)
    {
        try
        {
            CustomerNoteAttachment item = new()
            {
                Id = request.Id,
                IdCustomerNote = request.CustomerNoteId,
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

    public async ValueTask<CustomerNoteAttachment?> DeleteNoteAttachmentAsync(Ulid id)
    {
        try
        {
            var noteAttachment = await _context.NoteAttachments.FindAsync(id);
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