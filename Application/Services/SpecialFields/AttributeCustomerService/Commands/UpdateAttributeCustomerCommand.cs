namespace Application.Services.SpecialFields.AttributeCustomerService.Commands;

public struct UpdateAttributeCustomerCommand : IRequest<Result<AttributeCustomerResponse>>
{
    public Ulid Id { get; set; }
    public string Value { get; set; }
    // public StatusType Status { get; set; }
    public string? FilePath { get; set; }
}