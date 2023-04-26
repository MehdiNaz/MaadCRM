﻿namespace DataAccess.Repositories.SpecialFields;

public class BusinessAttributeRepository : IBusinessAttributeRepository
{
    private readonly MaadContext _context;

    public BusinessAttributeRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<BusinessAttribute?>> GetAllBusinessAttributesAsync()
        => await _context.BusinessAttributes.Where(x => x.BusinessAttributeStatus == Status.Show).ToListAsync();

    public async ValueTask<BusinessAttribute?> GetBusinessAttributeByIdAsync(int businessAttributeId)
        => await _context.BusinessAttributes.FindAsync(businessAttributeId);

    public async ValueTask<BusinessAttribute?> CreateBusinessAttributeAsync(BusinessAttribute? toCreate)
    {
        await _context.BusinessAttributes!.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<BusinessAttribute?> UpdateBusinessAttributeAsync(string updateContent, int businessAttributeId)
    {
        var businessAttribute = await GetBusinessAttributeByIdAsync(businessAttributeId);
        _context.Update(businessAttribute);
        await _context.SaveChangesAsync();
        return businessAttribute;
    }

    public async ValueTask<BusinessAttribute?> DeleteBusinessAttributeAsync(int businessAttributeId)
    {
        try
        {
            var businessAttribute = await _context.BusinessAttributes.FindAsync(businessAttributeId);
            //_context.BusinessAttributes!.Remove(businessAttribute);
            businessAttribute.BusinessAttributeStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return businessAttribute;
        }
        catch
        {
            return null;
        }
    }
}