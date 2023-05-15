namespace DataAccess.Repositories.SpecialFields;

public class AttributeRepository : IAttributeRepository
{
    private readonly MaadContext _context;

    public AttributeRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<AttributeResponse>>> GetAllAttributesAsync()
    {
        try
        {
            return new Result<ICollection<AttributeResponse>>(await _context.Attributes.Where(x => x.Status == StatusType.Show)
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
                })
                .ToListAsync());
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
            return new Result<AttributeResponse>(await _context.Attributes.FindAsync(attributeId)
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
                }));
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
            return await _context.Attributes.FindAsync(item.Id)
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