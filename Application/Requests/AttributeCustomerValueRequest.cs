namespace Application.Requests;

public struct AttributeCustomerValueRequest
{
    public string ValueString { get; set; }
    public string? FilePath { get; set; }
    public bool? ValueBool { get; set; }
    public DateOnly? ValueDate { get; set; }
    public int? ValueNumber { get; set; }
    public Ulid IdAttributeOption { get; set; }
}