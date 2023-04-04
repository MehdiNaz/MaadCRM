﻿namespace DataAccess.Repositories.Customers.PeyGiry;

public class PeyGiryAttachmentRepository : IPeyGiryAttachmentRepository
{
    private readonly MaadContext _context;

    public PeyGiryAttachmentRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<PeyGiryAttachment?>> GetAllPeyGiryAttachmentsAsync()
        => (await _context.PeyGiryAttachments!.ToListAsync()).Where(x => x.StatusPeyGiryAttachment == Status.Show).ToList()!;

    public async ValueTask<PeyGiryAttachment?> GetPeyGiryAttachmentByIdAsync(Ulid peyGiryAttachmentId)
        => await _context.PeyGiryAttachments!.FindAsync(peyGiryAttachmentId);

    public async ValueTask<PeyGiryAttachment?> CreatePeyGiryAttachmentAsync(PeyGiryAttachment? entity)
    {
        try
        {
            await _context.PeyGiryAttachments!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<PeyGiryAttachment?> UpdatePeyGiryAttachmentAsync(PeyGiryAttachment entity, Ulid peyGiryAttachmentId)
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

    public async ValueTask<PeyGiryAttachment?> DeletePeyGiryAttachmentAsync(Ulid peyGiryAttachmentId)
    {
        try
        {
            var peyGiryAttachment = await GetPeyGiryAttachmentByIdAsync(peyGiryAttachmentId);
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