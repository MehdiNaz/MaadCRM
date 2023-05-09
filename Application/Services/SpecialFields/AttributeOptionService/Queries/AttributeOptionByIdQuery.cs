namespace Application.Services.SpecialFields.AttributeOptionService.Queries;

public struct AttributeOptionByIdQuery : IRequest<Result<AttributeOptionResponse>>
{
    public Ulid Id { get; set; }
}