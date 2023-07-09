namespace Application.Services.SpecialFields.AttributeService.Queries;

public struct AllAttributeQuery : IRequest<Result<ICollection<AttributeResponse>>>
{
    public string IdUser { get; set; }
    public AttributeType Type { get; set; }
}