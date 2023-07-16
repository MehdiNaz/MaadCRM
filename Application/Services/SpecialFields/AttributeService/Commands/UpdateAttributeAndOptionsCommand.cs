﻿namespace Application.Services.SpecialFields.AttributeService.Commands;

public struct UpdateAttributeAndOptionsCommand : IRequest<Result<AttributeResponse>>
{
    public Ulid Id { get; set; }
    public string Label { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsRequired { get; set; }
    public AttributeInputType AttributeInputTypeId { get; set; }
    public AttributeType AttributeTypeId { get; set; }
    public int? ValidationMinLength { get; set; }
    public int? ValidationMaxLength { get; set; }
    public string ValidationFileAllowExtension { get; set; }
    public int? ValidationFileMaximumSize { get; set; }
    public string? DefaultValue { get; set; }
    public Ulid? IdBusiness { get; set; }
    public string IdUserUpdated { get; set; }
    
    public List<AttributeOptionRequest>? Options { get; set; }
}