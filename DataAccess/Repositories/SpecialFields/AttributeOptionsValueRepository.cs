namespace DataAccess.Repositories.SpecialFields;

public class AttributeOptionsValueRepository : IAttributeOptionsValueRepository
{
    private readonly MaadContext _context;

    public AttributeOptionsValueRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<AttributeOptionValueResponse>>> GetAllAttributeOptionsValueAsync()
    {
        try
        {
            return new Result<ICollection<AttributeOptionValueResponse>>(await _context.AttributeOptionsValues.Where(x => x.Status == StatusType.Show)
                .Select(x => new AttributeOptionValueResponse
                {
                    Id = x.Id,
                    Status = x.Status,
                    FilePath = x.FilePath,
                    IdAttributeOption = x.IdAttributeOption,
                    Value = x.Value
                })
                .ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<AttributeOptionValueResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeOptionValueResponse>> GetAttributeOptionsValueByIdAsync(Ulid attributeOptionsValueId)
    {
        try
        {
            return new Result<AttributeOptionValueResponse>(await _context.AttributeOptionsValues
                .FirstOrDefaultAsync(x => x.Id == attributeOptionsValueId && x.Status == StatusType.Show)
                .Select(x => new AttributeOptionValueResponse
                {
                    Id = x.Id,
                    Status = x.Status,
                    Value = x.Value,
                    IdAttributeOption = x.IdAttributeOption,
                    FilePath = x.FilePath
                }));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeOptionValueResponse>> ChangeStatusAttributeOptionsByIdAsync(ChangeStatusAttributeOptionValueCommand request)
    {
        try
        {
            var item = await _context.AttributeOptionsValues.FindAsync(request.Id);
            if (item is null) return new Result<AttributeOptionValueResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.Status = request.Status;
            await _context.SaveChangesAsync();
            return await _context.AttributeOptionsValues.FindAsync(request.Id)
                .Select(x => new AttributeOptionValueResponse
                {
                    Id = x.Id,
                    Status = x.Status,
                    Value = x.Value,
                    IdAttributeOption = x.IdAttributeOption,
                    FilePath = x.FilePath
                });
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeOptionValueResponse>> CreateAttributeOptionsValueAsync(CreateAttributeOptionValueCommand request)
    {
        try
        {
            AttributeOptionValue item = new()
            {
                Value = request.Value,
                IdAttributeOption = request.IdAttributeOption,
                FilePath = request.FilePath
            };
            await _context.AttributeOptionsValues.AddAsync(item);
            await _context.SaveChangesAsync();
            return await _context.AttributeOptionsValues.FindAsync(item.Id)
                .Select(x => new AttributeOptionValueResponse
                {
                    Id = x.Id,
                    Status = x.Status,
                    Value = x.Value,
                    IdAttributeOption = x.IdAttributeOption,
                    FilePath = x.FilePath
                });
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeOptionValueResponse>> UpdateAttributeOptionsValueAsync(UpdateAttributeOptionValueCommand request)
    {
        try
        {
            AttributeOptionValue item = await _context.AttributeOptionsValues.FindAsync(request.Id);

            item.Value = request.Value;
            item.FilePath = request.FilePath;

            await _context.SaveChangesAsync();
            return await _context.AttributeOptionsValues.FindAsync(request.Id)
                .Select(x => new AttributeOptionValueResponse
                {
                    Id = x.Id,
                    Status = x.Status,
                    Value = x.Value,
                    IdAttributeOption = x.IdAttributeOption,
                    FilePath = x.FilePath
                });
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeOptionValueResponse>> DeleteAttributeOptionsValueAsync(Ulid attributeOptionsValueId)
    {
        try
        {
            var item = await _context.AttributeOptionsValues.FindAsync(attributeOptionsValueId);
            item!.Status = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return await _context.AttributeOptionsValues.FindAsync(attributeOptionsValueId)
                .Select(x => new AttributeOptionValueResponse
                {
                    Id = x.Id,
                    Status = x.Status,
                    Value = x.Value,
                    IdAttributeOption = x.IdAttributeOption,
                    FilePath = x.FilePath
                });
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new ValidationException(e.Message));
        }
    }
}