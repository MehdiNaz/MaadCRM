namespace Application.Services.SpecialFields.AttributeCustomerService.Commands;

public struct DeleteAttributeCustomerCommand: IRequest<Result<AttributeCustomerResponse>>
{
    public Ulid Id { get; set; }
}