using Application.Responses.SpecialFields;

namespace DataAccess.Repositories.SpecialFields;

public class AttributeOptionsRepository : IAttributeOptionsRepository
{
    private readonly MaadContext _context;

    public AttributeOptionsRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<AttributeOptionResponse>>> GetAllAttributeOptionsAsync()
    {
        try
        {
            return new Result<ICollection<AttributeOptionResponse>>(await _context.AttributeOptions.Where(x => x.Status == StatusType.Show)
                .Select(x => new AttributeOptionResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    ColorSquaresRgb = x.ColorSquaresRgb,
                    DisplayOrder = x.DisplayOrder,
                    Status = x.Status,
                    IdAttribute = x.IdAttribute
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<AttributeOptionResponse>>(new ValidationException(e.Message));
        }

    }

    public async ValueTask<Result<AttributeOptionResponse>> GetAttributeOptionsByIdAsync(Ulid attributeOptionsId)
    {
        try
        {
            return new Result<AttributeOptionResponse>(await _context.AttributeOptions
                .FirstOrDefaultAsync(x => x.Id == attributeOptionsId && x.Status == StatusType.Show)
                .Select(x => new AttributeOptionResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    ColorSquaresRgb = x.ColorSquaresRgb,
                    DisplayOrder = x.DisplayOrder,
                    Status = x.Status,
                    IdAttribute = x.IdAttribute
                }));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new ValidationException(e.Message));
        }
    }
    public async ValueTask<Result<AttributeOptionResponse>> ChangeStatusAttributeIdAsync(ChangeStatusAttributeOptionCommand request)
    {
        try
        {
            var item = await _context.AttributeOptions.FindAsync(request.Id);
            if (item is null) return new Result<AttributeOptionResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.Status = request.Status;
            await _context.SaveChangesAsync();
            return await _context.AttributeOptions.FindAsync(request.Id)
                .Select(x => new AttributeOptionResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    ColorSquaresRgb = x.ColorSquaresRgb,
                    DisplayOrder = x.DisplayOrder,
                    Status = x.Status,
                    IdAttribute = x.IdAttribute
                });
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new ValidationException(e.Message));
        }
    }
    public async ValueTask<Result<AttributeOptionResponse>> CreateAttributeOptionsAsync(CreateAttributeOptionCommand request)
    {
        try
        {
            AttributeOption item = new()
            {
                Title = request.Title,
                ColorSquaresRgb = request.ColorSquaresRgb,
                DisplayOrder = request.DisplayOrder,
                IdAttribute = request.IdAttribute
            };

            await _context.AttributeOptions.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<AttributeOptionResponse>( await _context.AttributeOptions.FindAsync(item.Id)
                .Select(x => new AttributeOptionResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    ColorSquaresRgb = x.ColorSquaresRgb,
                    DisplayOrder = x.DisplayOrder,
                    Status = x.Status,
                    IdAttribute = x.IdAttribute
                }));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new ValidationException(e.Message));
        }
    }
    public async ValueTask<Result<AttributeOptionResponse>> UpdateAttributeOptionsAsync(UpdateAttributeOptionCommand request)
    {
        try
        {
            AttributeOption item = await _context.AttributeOptions.FindAsync(request.Id);

            item.Title = request.Title;
            item.ColorSquaresRgb = request.ColorSquaresRgb;
            item.DisplayOrder = request.DisplayOrder;

            await _context.SaveChangesAsync();
            return await _context.AttributeOptions.FindAsync(item.Id)
                .Select(x => new AttributeOptionResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    ColorSquaresRgb = x.ColorSquaresRgb,
                    DisplayOrder = x.DisplayOrder,
                    Status = x.Status,
                    IdAttribute = x.IdAttribute
                });
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new ValidationException(e.Message));
        }
    }
    public async ValueTask<Result<AttributeOptionResponse>> DeleteAttributeOptionsAsync(Ulid attributeOptionsId)
    {
        try
        {
            var item = await _context.AttributeOptions.FindAsync(attributeOptionsId);
            item!.Status = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return await _context.AttributeOptions.FindAsync(item.Id)
                .Select(x => new AttributeOptionResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    ColorSquaresRgb = x.ColorSquaresRgb,
                    DisplayOrder = x.DisplayOrder,
                    Status = x.Status,
                    IdAttribute = x.IdAttribute
                });
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new ValidationException(e.Message));
        }
    }
}