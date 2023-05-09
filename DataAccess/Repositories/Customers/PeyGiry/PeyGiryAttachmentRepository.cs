namespace DataAccess.Repositories.Customers.PeyGiry;

public class PeyGiryAttachmentRepository : IPeyGiryAttachmentRepository
{
    private readonly MaadContext _context;

    public PeyGiryAttachmentRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<PeyGiryAttachment?>> GetAllPeyGiryAttachmentsAsync()
        => await _context.PeyGiryAttachments.Where(x => x.StatusTypePeyGiryAttachment == StatusType.Show).ToListAsync();

    public async ValueTask<PeyGiryAttachment?> GetPeyGiryAttachmentByIdAsync(Ulid peyGiryAttachmentId)
        => await _context.PeyGiryAttachments.FirstOrDefaultAsync(x => x.Id == peyGiryAttachmentId && x.StatusTypePeyGiryAttachment == StatusType.Show);

    public async ValueTask<PeyGiryAttachment?> ChangeStatusPeyGiryAttachmentByIdAsync(ChangeStatusPeyGiryAttachmentCommand request)
    {
        try
        {
            var item = await _context.PeyGiryAttachments!.FindAsync(request.Id);
            if (item is null) return null;
            item.StatusTypePeyGiryAttachment = request.StatusTypePeyGiryAttachment;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<PeyGiryAttachment?> CreatePeyGiryAttachmentAsync(CreatePeyGiryAttachmentCommand request)
    {
        try
        {
            PeyGiryAttachment item = new()
            {
                IdPeyGiry = request.PeyGiryNoteId,
                FileName = request.FileName,
                Extenstion = request.Extenstion
            };
            await _context.PeyGiryAttachments!.AddAsync(item!);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<PeyGiryAttachment?> UpdatePeyGiryAttachmentAsync(UpdatePeyGiryAttachmentCommand request)
    {
        try
        {
            PeyGiryAttachment item = await _context.PeyGiryAttachments.FindAsync(request.Id);
            item.IdPeyGiry = request.PeyGiryNoteId;
            item.FileName = request.FileName;
            item.Extenstion = request.Extenstion;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<PeyGiryAttachment?> DeletePeyGiryAttachmentAsync(Ulid id)
    {
        try
        {
            var peyGiryAttachment = await _context.PeyGiryAttachments.FindAsync(id);
            peyGiryAttachment!.StatusTypePeyGiryAttachment = StatusType.Show;
            await _context.SaveChangesAsync();
            return peyGiryAttachment;
        }
        catch
        {
            return null;
        }
    }
}