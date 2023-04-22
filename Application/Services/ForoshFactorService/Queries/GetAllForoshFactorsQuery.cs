using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.Queries;

public struct GetAllForoshFactorsQuery : IRequest<ICollection<ForooshFactor>>
{
}