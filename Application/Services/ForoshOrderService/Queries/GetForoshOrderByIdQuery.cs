using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshOrderService.Queries;

public struct GetForoshOrderByIdQuery : IRequest<ForooshOrder>
{
    public Ulid ForoshOrderId { get; set; }
}