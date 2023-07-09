namespace Application.Services.SpecialFields.AttributeCustomerService.Commands;

public struct CreateAttributeCustomerCommand : IRequest<Result<AttributeCustomerResponse>>
{
    public string ValueString { get; set; }
    public string? FilePath { get; set; }
    public bool? ValueBool { get; set; }
    public DateOnly? ValueDate { get; set; }
    public int? ValueNumber { get; set; }
    
    public Ulid? IdAttributeOption { get; set; }
    public Ulid IdCustomer { get; set; }

}