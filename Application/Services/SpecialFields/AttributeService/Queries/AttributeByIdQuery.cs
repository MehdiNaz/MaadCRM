namespace Application.Services.SpecialFields.AttributeService.Queries;

public struct AttributeByIdQuery : IRequest<Result<AttributeResponse>>
{
    public Ulid Id { get; set; }
}