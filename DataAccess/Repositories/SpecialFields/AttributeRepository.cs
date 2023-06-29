namespace DataAccess.Repositories.SpecialFields;

public class AttributeRepository : IAttributeRepository
{
    private readonly MaadContext _context;

    public AttributeRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<AttributeResponse>>> GetAllAttributesAsync(AttributeType type,Ulid idBusiness)
    {
        try
        {
            var result = await _context
                .Attributes
                .Where(x => x.Status == StatusType.Show && x.AttributeTypeId == type && x.IdBusiness == idBusiness)
                .Select(x => new AttributeResponse
                {
                    Id = x.Id,
                    Label = x.Label,
                    DisplayOrder = x.DisplayOrder,
                    IsRequired = x.IsRequired,
                    IdAttributeInputType = x.AttributeInputTypeId,
                    IdAttributeType = x.AttributeTypeId,
                    ValidationMinLength = x.ValidationMinLength,
                    ValidationMaxLength = x.ValidationMaxLength,
                    ValidationFileAllowExtension = x.ValidationFileAllowExtension,
                    ValidationFileMaximumSize = x.ValidationFileMaximumSize,
                    DefaultValue = x.DefaultValue,
                    IdBusiness = x.IdBusiness,
                    AttributeOptions = x.AttributeOptions.Select(x => new AttributeOptionResponse
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ColorSquaresRgb = x.ColorSquaresRgb,
                        DisplayOrder = x.DisplayOrder,
                        Status = x.Status,
                        IdAttribute = x.IdAttribute
                    }).ToList()
                })
                .ToListAsync();
            
            return new Result<ICollection<AttributeResponse>>(result);

        }
        catch (Exception e)
        {
            return new Result<ICollection<AttributeResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeResponse>> GetAttributesByIdAsync(Ulid attributeId)
    {
        try
        {
            var result = await _context
                .Attributes
                .Select(x => new AttributeResponse
                {
                    Id = x.Id,
                    Label = x.Label,
                    DisplayOrder = x.DisplayOrder,
                    IsRequired = x.IsRequired,
                    IdAttributeInputType = x.AttributeInputTypeId,
                    IdAttributeType = x.AttributeTypeId,
                    ValidationMinLength = x.ValidationMinLength,
                    ValidationMaxLength = x.ValidationMaxLength,
                    ValidationFileAllowExtension = x.ValidationFileAllowExtension,
                    ValidationFileMaximumSize = x.ValidationFileMaximumSize,
                    DefaultValue = x.DefaultValue,
                    IdBusiness = x.IdBusiness,
                    AttributeOptions = x.AttributeOptions.Select(x => new AttributeOptionResponse
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ColorSquaresRgb = x.ColorSquaresRgb,
                        DisplayOrder = x.DisplayOrder,
                        Status = x.Status,
                        IdAttribute = x.IdAttribute
                    }).ToList()
                })
                .FirstOrDefaultAsync(w => w.Id == attributeId);
            
            return new Result<AttributeResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeResponse>> ChangeStatusAttributeIdAsync(ChangeStatusAttributeCommand request)
    {
        try
        {
            var item = await _context.Attributes.FindAsync(request.Id);
            if (item is null) return new Result<AttributeResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.Status = request.Status;
            await _context.SaveChangesAsync();
            return await _context.Attributes.FindAsync(request.Id)
                    .Select(x => new AttributeResponse
                    {
                        Id = x.Id,
                        Label = x.Label,
                        DisplayOrder = x.DisplayOrder,
                        IsRequired = x.IsRequired,
                        IdAttributeInputType = x.AttributeInputTypeId,
                        IdAttributeType = x.AttributeTypeId,
                        ValidationMinLength = x.ValidationMinLength,
                        ValidationMaxLength = x.ValidationMaxLength,
                        ValidationFileAllowExtension = x.ValidationFileAllowExtension,
                        ValidationFileMaximumSize = x.ValidationFileMaximumSize,
                        DefaultValue = x.DefaultValue,
                        IdBusiness = x.IdBusiness
                    });
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeResponse>> CreateAttributesAsync(CreateAttributeCommand request)
    {
        try
        {
            Attribute item = new()
            {
                Label = request.Label,
                DisplayOrder = request.DisplayOrder,
                IsRequired = request.IsRequired,
                AttributeInputTypeId = request.AttributeInputTypeId,
                AttributeTypeId = request.AttributeTypeId,
                ValidationMinLength = request.ValidationMinLength,
                ValidationMaxLength = request.ValidationMaxLength,
                ValidationFileAllowExtension = request.ValidationFileAllowExtension,
                ValidationFileMaximumSize = request.ValidationFileMaximumSize,
                DefaultValue = request.DefaultValue,
                IdBusiness = request.IdBusiness,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated,
            };
            await _context.Attributes.AddAsync(item);
            await _context.SaveChangesAsync();

            if (request.Options is not null)
            {
                foreach (var option in request.Options)
                {
                    AttributeOption itemOption = new()
                    {
                        Title = option.Title,
                        ColorSquaresRgb = option.ColorSquaresRgb,
                        DisplayOrder = option.DisplayOrder,
                        IdAttribute = item.Id
                    };
                    await _context.AttributeOptions.AddAsync(itemOption);
                }

                await _context.SaveChangesAsync();
            }


            return await _context.Attributes
                .Select(x => new AttributeResponse
                {
                    Id = x.Id,
                    Label = x.Label,
                    DisplayOrder = x.DisplayOrder,
                    IsRequired = x.IsRequired,
                    IdAttributeInputType = x.AttributeInputTypeId,
                    IdAttributeType = x.AttributeTypeId,
                    ValidationMinLength = x.ValidationMinLength,
                    ValidationMaxLength = x.ValidationMaxLength,
                    ValidationFileAllowExtension = x.ValidationFileAllowExtension,
                    ValidationFileMaximumSize = x.ValidationFileMaximumSize,
                    DefaultValue = x.DefaultValue,
                    IdBusiness = x.IdBusiness,
                    AttributeOptions = x.AttributeOptions.Select(x => new AttributeOptionResponse
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ColorSquaresRgb = x.ColorSquaresRgb,
                        DisplayOrder = x.DisplayOrder,
                        Status = x.Status,
                        IdAttribute = x.IdAttribute
                    }).ToList()
                })
                .FirstOrDefaultAsync(w => w.Id == item.Id);
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeResponse>> UpdateAttributesAsync(UpdateAttributeCommand request)
    {
        try
        {
            Attribute item = await _context.Attributes.FindAsync(request.Id);

            item.Label = request.Label;
            item.DisplayOrder = request.DisplayOrder;
            item.IsRequired = request.IsRequired;
            item.AttributeInputTypeId = request.AttributeInputTypeId;
            item.AttributeTypeId = request.AttributeTypeId;
            item.ValidationMinLength = request.ValidationMinLength;
            item.ValidationMaxLength = request.ValidationMaxLength;
            item.ValidationFileAllowExtension = request.ValidationFileAllowExtension;
            item.ValidationFileMaximumSize = request.ValidationFileMaximumSize;
            item.DefaultValue = request.DefaultValue;
            item.IdBusiness = request.IdBusiness;
            item.IdUserUpdated = request.IdUserUpdated;

            await _context.SaveChangesAsync();
            return await _context.Attributes.FindAsync(request.Id)
                .Select(x => new AttributeResponse
                {
                    Id = x.Id,
                    Label = x.Label,
                    DisplayOrder = x.DisplayOrder,
                    IsRequired = x.IsRequired,
                    IdAttributeInputType = x.AttributeInputTypeId,
                    IdAttributeType = x.AttributeTypeId,
                    ValidationMinLength = x.ValidationMinLength,
                    ValidationMaxLength = x.ValidationMaxLength,
                    ValidationFileAllowExtension = x.ValidationFileAllowExtension,
                    ValidationFileMaximumSize = x.ValidationFileMaximumSize,
                    DefaultValue = x.DefaultValue,
                    IdBusiness = x.IdBusiness
                });
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeResponse>> DeleteAttributesAsync(Ulid attributeId)
    {
        try
        {
            var item = await _context.Attributes.FindAsync(attributeId);
            item!.Status = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return await _context.Attributes.FindAsync(attributeId)
                .Select(x => new AttributeResponse
                {
                    Id = x.Id,
                    Label = x.Label,
                    DisplayOrder = x.DisplayOrder,
                    IsRequired = x.IsRequired,
                    IdAttributeInputType = x.AttributeInputTypeId,
                    IdAttributeType = x.AttributeTypeId,
                    ValidationMinLength = x.ValidationMinLength,
                    ValidationMaxLength = x.ValidationMaxLength,
                    ValidationFileAllowExtension = x.ValidationFileAllowExtension,
                    ValidationFileMaximumSize = x.ValidationFileMaximumSize,
                    DefaultValue = x.DefaultValue,
                    IdBusiness = x.IdBusiness
                });
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new ValidationException(e.Message));
        }
    }
}