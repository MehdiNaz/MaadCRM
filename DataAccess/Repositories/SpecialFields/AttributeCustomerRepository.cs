using Application.Responses.SpecialFields;
using Application.Services.SpecialFields.AttributeCustomerService.Commands;

namespace DataAccess.Repositories.SpecialFields;

public class AttributeCustomerRepository : IAttributeCustomerRepository
{
    private readonly MaadContext _context;

    public AttributeCustomerRepository(MaadContext context)
    {
        _context = context;
    }
    
    private async ValueTask<Result<AttributeCustomerResponse>> GetCustomerAttributes(Ulid attributeOptionId)
    {
        try
        {
            var resultOption = await _context.AttributeOptions.FindAsync(attributeOptionId);
            var result = await _context
                .Attributes
                .Include(attribute => attribute.AttributeOptions!)
                .ThenInclude(attributeOption => attributeOption.CustomerAttributes!)
                .FirstOrDefaultAsync(w => w.Status == StatusType.Show && w.Id == resultOption.IdAttribute)
                    .Select(x => new AttributeCustomerResponse
                    {
                        Id = x.Id,
                        Label = x.Label,
                        DisplayOrder = x.DisplayOrder,
                        IsRequired = x.IsRequired,
                        InputType = x.AttributeInputTypeId,
                        Type = x.AttributeTypeId,
                        ValidationMinLength = x.ValidationMinLength,
                        ValidationMaxLength = x.ValidationMaxLength,
                        ValidationFileAllowExtension = x.ValidationFileAllowExtension,
                        ValidationFileMaximumSize = x.ValidationFileMaximumSize,
                        DefaultValue = x.DefaultValue,
                        IdBusiness = x.IdBusiness,
                        AttributeOptions = x.AttributeOptions!.Select(s => new AttributeCustomerOptionsResponse
                        {
                            Id = s.Id,
                            Title = s.Title,
                            ColorSquaresRgb = s.ColorSquaresRgb,
                            DisplayOrder = s.DisplayOrder,
                            Status = s.Status,
                            Value = s.CustomerAttributes!
                                .Where(w => w.IdAttributeOption == s.Id && w.Status == StatusType.Show).Select(v =>
                                    new AttributeCustomerValueResponse
                                    {
                                        Id = v.Id,
                                        Status = v.Status,
                                        ValueString = v.ValueString,
                                        FilePath = v.FilePath,
                                        ValueNumber = v.ValueNumber,
                                        ValueBool = v.ValueBool,
                                        ValueDate = v.ValueDate,
                                        IdCustomer = v.IdCustomer
                                    }).ToList()
                        }).ToList()
                    });
            
            return new Result<AttributeCustomerResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<AttributeCustomerResponse>>> GetAllAttributesAsync(Ulid idCustomer)
    {
        try
        {
            var result = await _context
                .Attributes
                .Select(x => new AttributeCustomerResponse
                {
                    Id = x.Id,
                    Label = x.Label,
                    DisplayOrder = x.DisplayOrder,
                    IsRequired = x.IsRequired,
                    InputType = x.AttributeInputTypeId,
                    Type = x.AttributeTypeId,
                    ValidationMinLength = x.ValidationMinLength,
                    ValidationMaxLength = x.ValidationMaxLength,
                    ValidationFileAllowExtension = x.ValidationFileAllowExtension,
                    ValidationFileMaximumSize = x.ValidationFileMaximumSize,
                    DefaultValue = x.DefaultValue,
                    IdBusiness = x.IdBusiness,
                    AttributeOptions = x.AttributeOptions!.Select(s => new AttributeCustomerOptionsResponse
                    {
                        Id = s.Id,
                        Title = s.Title,
                        ColorSquaresRgb = s.ColorSquaresRgb,
                        DisplayOrder = s.DisplayOrder,
                        Status = s.Status,
                        Value = s.CustomerAttributes!
                            .Where(w => w.IdCustomer == idCustomer && w.IdAttributeOption == s.Id).Select(v =>
                                new AttributeCustomerValueResponse
                                {
                                    Id = v.Id,
                                    Status = v.Status,
                                    ValueString = v.ValueString,
                                    FilePath = v.FilePath,
                                    ValueNumber = v.ValueNumber,
                                    ValueBool = v.ValueBool,
                                    ValueDate = v.ValueDate,
                                    IdCustomer = v.IdCustomer
                                }).ToList()
                    }).ToList()
                }).ToListAsync();
            
            return new Result<ICollection<AttributeCustomerResponse>>(result);

        }
        catch (Exception e)
        {
            return new Result<ICollection<AttributeCustomerResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeCustomerResponse>> GetAttributeByIdAsync(Ulid attributeId)
    {
        try
        {
            var result = await GetCustomerAttributes(attributeId);
            return result.Match(
                succ => new Result<AttributeCustomerResponse>(succ),
                exception => new Result<AttributeCustomerResponse>(exception)
            );
            
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeCustomerResponse>> ChangeStatusAttributeIdAsync(ChangeStatusAttributeCustomerCommand request)
    {
        try
        {
            var itemValue = await _context.AttributesCustomer.FindAsync(request.Id);
            if (itemValue is null) return new Result<AttributeCustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));

            // var itemAttribute = await _context.Attributes.FindAsync(itemValue.IdAttributeOptionNavigation!.IdAttribute);
            // if (itemAttribute is null) return new Result<AttributeCustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));
            

            itemValue.Status = request.Status;
            await _context.SaveChangesAsync();
            
            var result = await GetCustomerAttributes(itemValue.IdAttributeOptionNavigation.IdAttribute.Value);
            return result.Match(
                succ => new Result<AttributeCustomerResponse>(succ),
                exception => new Result<AttributeCustomerResponse>(exception)
            );
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeCustomerResponse>> CreateAttributesAsync(CreateAttributeCustomerCommand request)
    {
        try
        {
            Result<AttributeCustomerResponse> result;

            
            var find = await _context.AttributesCustomer.FirstOrDefaultAsync(w => w.IdCustomer == request.IdCustomer && w.IdAttributeOption == request.IdAttributeOption);
            if (find is not null)
            {
                find.ValueDate = request.ValueDate;
                find.ValueBool = request.ValueBool;
                find.ValueNumber = request.ValueNumber;
                find.ValueString = request.ValueString;
                find.FilePath = request.FilePath;
                find.Status = StatusType.Show;
                await _context.SaveChangesAsync();
                
                result = await GetCustomerAttributes(find.IdAttributeOption.Value);
                return result.Match(
                    succ => new Result<AttributeCustomerResponse>(succ),
                    exception => new Result<AttributeCustomerResponse>(exception)
                );
            }
            
            AttributeCustomer item = new()
            {  
                IdAttributeOption = request.IdAttributeOption,
                IdCustomer = request.IdCustomer,
                Status = StatusType.Show,
                ValueString = request.ValueString,
                ValueNumber = request.ValueNumber,
                ValueBool = request.ValueBool,
                ValueDate = request.ValueDate,
                FilePath = request.FilePath
            };
            await _context.AttributesCustomer.AddAsync(item);
            await _context.SaveChangesAsync();
                
            result = await GetCustomerAttributes(item.IdAttributeOption!.Value);
            return result.Match(
                succ => new Result<AttributeCustomerResponse>(succ),
                exception => new Result<AttributeCustomerResponse>(exception)
            );
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeCustomerResponse>> UpdateAttributesAsync(UpdateAttributeCustomerCommand request)
    {
        try
        {
            
            var itemValue = await _context.AttributesCustomer.FindAsync(request.Id);
            if (itemValue is null) return new Result<AttributeCustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));

            // var itemAttribute = await _context.Attributes.FindAsync(itemValue.IdAttributeOptionNavigation!.IdAttribute);
            // if (itemAttribute is null) return new Result<AttributeCustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));
            

            // itemValue.Status = request.Status;
            itemValue.ValueString = request.Value;
            itemValue.FilePath = request.FilePath;
            
            await _context.SaveChangesAsync();
            
            var result = await GetCustomerAttributes(itemValue.IdAttributeOptionNavigation.IdAttribute.Value);
            return result.Match(
                succ => new Result<AttributeCustomerResponse>(succ),
                exception => new Result<AttributeCustomerResponse>(exception)
            );
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<AttributeCustomerResponse>> DeleteAttributesAsync(Ulid attributeCustomerId)
    {
        try
        {
            var itemValue = await _context.AttributesCustomer.FindAsync(attributeCustomerId);
            if (itemValue is null) return new Result<AttributeCustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));

            // var itemAttribute = await _context.Attributes.FindAsync(itemValue.IdAttributeOptionNavigation!.IdAttribute);
            // if (itemAttribute is null) return new Result<AttributeCustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));
            

            itemValue.Status = StatusType.Deleted;
            await _context.SaveChangesAsync();
            
            var result = await GetCustomerAttributes(itemValue.IdAttributeOptionNavigation.IdAttribute.Value);
            return result.Match(
                succ => new Result<AttributeCustomerResponse>(succ),
                exception => new Result<AttributeCustomerResponse>(exception)
            );
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new ValidationException(e.Message));
        }
    }
}