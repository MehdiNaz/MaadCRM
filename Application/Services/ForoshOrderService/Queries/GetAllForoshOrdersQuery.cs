using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshOrderService.Queries;

public struct GetAllForoshOrdersQuery : IRequest<ICollection<ForooshOrder>>
{
}