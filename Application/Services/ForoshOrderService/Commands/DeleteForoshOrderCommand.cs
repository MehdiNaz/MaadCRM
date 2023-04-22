using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshOrderService.Commands;

public struct DeleteForoshOrderCommand : IRequest<ForooshOrder>
{
    public Ulid Id { get; set; }
}