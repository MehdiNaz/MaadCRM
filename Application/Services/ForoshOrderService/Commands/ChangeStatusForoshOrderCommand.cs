using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshOrderService.Commands;

public struct ChangeStatusForoshOrderCommand : IRequest<ForooshOrder?>
{
    public Ulid ForoshOrderId { get; set; }
    public Status ForoshOrderStatus { get; set; }
}