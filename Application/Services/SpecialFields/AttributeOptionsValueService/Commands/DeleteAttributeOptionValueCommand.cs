namespace Application.Services.SpecialFields.AttributeOptionsValueService.Commands;

public struct DeleteAttributeOptionValueCommand : IRequest<Result<AttributeOptionValueResponse>>
{
    public Ulid Id { get; set; }
}