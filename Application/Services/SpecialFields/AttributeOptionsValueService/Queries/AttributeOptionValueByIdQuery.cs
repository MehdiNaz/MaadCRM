namespace Application.Services.SpecialFields.AttributeOptionsValueService.Queries;

public struct AttributeOptionValueByIdQuery : IRequest<Result<AttributeOptionValueResponse>>
{
    public Ulid Id { get; set; }
}