namespace Application.Responses;

public struct AttributeResponse
{
    public Ulid Id { get; set; }
    public string Label { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsRequired { get; set; }
    public AttributeInputType IdAttributeInputType { get; set; }
    public AttributeType IdAttributeType { get; set; }
    public int? ValidationMinLength { get; set; }
    public int? ValidationMaxLength { get; set; }
    public string ValidationFileAllowExtension { get; set; }
    public int? ValidationFileMaximumSize { get; set; }
    public string? DefaultValue { get; set; }
    public Ulid? IdBusiness { get; set; }
    public string IdUserAdded { get; set; }
    public string IdUserUpdated { get; set; }
    

    public List<AttributeOptionResponse> AttributeOptions { get; set; }
}