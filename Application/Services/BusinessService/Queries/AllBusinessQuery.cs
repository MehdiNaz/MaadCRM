namespace Application.Services.BusinessService.Queries;

public struct AllBusinessQuery : IRequest<Result<ICollection<Business>>>
{
}