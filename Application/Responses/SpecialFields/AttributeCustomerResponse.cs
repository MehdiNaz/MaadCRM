namespace Application.Responses.SpecialFields;

public struct AttributeCustomerResponse
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
    

    public List<AttributeCustomerOptionsResponse> AttributeOptions { get; set; }
}


public struct AttributeCustomerOptionsResponse
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public string? ColorSquaresRgb { get; set; }
    public int? DisplayOrder { get; set; }
    public StatusType? Status { get; set; }
    
    public List<AttributeCustomerValueResponse> Value { get; set; }
}

public struct AttributeCustomerValueResponse
{
    public Ulid Id { get; set; }
    public StatusType? Status { get; set; }
    public string Value { get; set; }
    public string? FilePath { get; set; }

    public Ulid IdCustomer { get; set; }
}