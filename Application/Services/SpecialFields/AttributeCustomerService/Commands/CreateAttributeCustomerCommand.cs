namespace Application.Services.SpecialFields.AttributeCustomerService.Commands;

public struct CreateAttributeCustomerCommand : IRequest<Result<AttributeCustomerResponse>>
{
    public string Value { get; set; }
    public string? FilePath { get; set; }
    public Ulid? IdAttributeOption { get; set; }
    public Ulid IdCustomer { get; set; }

}