namespace DataAccess.Repositories.Customers.PeyGiry;

public class PeyGiryAttachmentRepository : IPeyGiryAttachmentRepository
{
    private readonly MaadContext _context;

    public PeyGiryAttachmentRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<PeyGiryAttachment?>> GetAllPeyGiryAttachmentsAsync()
        => await _context.PeyGiryAttachments.Where(x => x.StatusPeyGiryAttachment == Status.Show).ToListAsync();

    public async ValueTask<PeyGiryAttachment?> GetPeyGiryAttachmentByIdAsync(Ulid peyGiryAttachmentId)
        => await _context.PeyGiryAttachments.FirstOrDefaultAsync(x => x.Id == peyGiryAttachmentId && x.StatusPeyGiryAttachment == Status.Show);

    public async ValueTask<PeyGiryAttachment?> ChangeStatusPeyGiryAttachmentByIdAsync(ChangeStatusPeyGiryAttachmentCommand request)
    {
        try
        {
            var item = await _context.PeyGiryAttachments!.FindAsync(request.Id);
            if (item is null) return null;
            item.StatusPeyGiryAttachment = request.StatusPeyGiryAttachment;
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
                PeyGiryNoteId = request.PeyGiryNoteId,
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
            PeyGiryAttachment item = new()
            {
                Id = request.Id,
                PeyGiryNoteId = request.PeyGiryNoteId,
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

    public async ValueTask<PeyGiryAttachment?> DeletePeyGiryAttachmentAsync(DeletePeyGiryAttachmentCommand request)
    {
        try
        {
            var peyGiryAttachment = await GetPeyGiryAttachmentByIdAsync(request.Id);
            peyGiryAttachment!.StatusPeyGiryAttachment = Status.Show;
            await _context.SaveChangesAsync();
            return peyGiryAttachment;
        }
        catch
        {
            return null;
        }
    }
}