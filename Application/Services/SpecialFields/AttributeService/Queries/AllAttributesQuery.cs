namespace Application.Services.SpecialFields.AttributeService.Queries;

public struct AllAttributeQuery : IRequest<Result<ICollection<AttributeResponse>>>
{
}