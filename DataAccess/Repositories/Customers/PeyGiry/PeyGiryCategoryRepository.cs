namespace DataAccess.Repositories.Customers.PeyGiry;

public class PeyGiryCategoryRepository : IPeyGiryCategoryRepository
{
    private readonly MaadContext _context;

    public PeyGiryCategoryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<PeyGiryCategoryResponse>>> GetAllPeyGiryCategoriesAsync(Ulid businessId)
    {
        try
        {
            return await _context.PeyGiryCategories
                .Where(x => x.Status == StatusType.Show && x.BusinessId == businessId)
                .Select(x => new PeyGiryCategoryResponse
                {
                    Id = x.Id,
                    Kind = x.Kind,
                    IdBusiness = x.BusinessId,
                    Status = x.Status
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<PeyGiryCategoryResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<PeyGiryCategoryResponse>> GetPeyGiryCategoryByIdAsync(Ulid peyGiryCategoryId)
    {
        try
        {
            return await _context.PeyGiryCategories.SingleOrDefaultAsync(x => x.Id == peyGiryCategoryId && x.Status == StatusType.Show)
                .Select(x => new PeyGiryCategoryResponse
                {
                    Id = x.Id,
                    Kind = x.Kind,
                    IdBusiness = x.BusinessId,
                    Status = x.Status
                });
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<PeyGiryCategoryResponse>> ChangeStatusPeyGiryCategoryByIdAsync(ChangeStatusPeyGiryCategoryCommand request)
    {
        try
        {
            var item = await _context.PeyGiryCategories.FindAsync(request.Id);
            if (item is null) return new Result<PeyGiryCategoryResponse>(new ValidationException());
            item.Status = request.Status;
            await _context.SaveChangesAsync();
            return await _context.PeyGiryCategories.FindAsync(request.Id).Select(x => new PeyGiryCategoryResponse
            {
                Id = x.Id,
                Kind = x.Kind,
                IdBusiness = x.BusinessId,
                Status = x.Status
            });
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<PeyGiryCategoryResponse>> CreatePeyGiryCategoryAsync(CreatePeyGiryCategoryCommand request)
    {
        try
        {
            PeyGiryCategory item = new()
            {
                Kind = request.Kind,
                BusinessId = request.BusinessId,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };

            await _context.PeyGiryCategories.AddAsync(item);


            await _context.SaveChangesAsync();
            return await _context.PeyGiryCategories.FindAsync(item.Id).Select(x => new PeyGiryCategoryResponse
            {
                Id = x.Id,
                Kind = x.Kind,
                IdBusiness = x.BusinessId,
                Status = x.Status
            });
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<PeyGiryCategoryResponse>> UpdatePeyGiryCategoryAsync(UpdatePeyGiryCategoryCommand request)
    {
        try
        {
            PeyGiryCategory item = await _context.PeyGiryCategories.FindAsync(request.Id);
            item.Kind = request.Kind;
            item.BusinessId = request.BusinessId;
            item.IdUserUpdated = request.IdUserUpdated;
            await _context.SaveChangesAsync();
            return await _context.PeyGiryCategories.FindAsync(request.Id).Select(x => new PeyGiryCategoryResponse
            {
                Id = x.Id,
                Kind = x.Kind,
                IdBusiness = x.BusinessId,
                Status = x.Status
            });
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<PeyGiryCategoryResponse>> DeletePeyGiryCategoryAsync(Ulid peyGiryCategoryId)
    {
        try
        {
            var item = await _context.PeyGiryCategories.FindAsync(peyGiryCategoryId);
            item.Status = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return await _context.PeyGiryCategories.FindAsync(peyGiryCategoryId).Select(x => new PeyGiryCategoryResponse
            {
                Id = x.Id,
                Kind = x.Kind,
                IdBusiness = x.BusinessId,
                Status = x.Status
            });
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new ValidationException(e.Message));
        }
    }
}