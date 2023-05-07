namespace Application.Services.ForoshFactorService.Queries;

public struct GetAllForoshFactorsQuery : IRequest<Result<ICollection<ForooshFactor>>>
{
}