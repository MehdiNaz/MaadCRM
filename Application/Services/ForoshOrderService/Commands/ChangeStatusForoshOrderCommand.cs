namespace Application.Services.ForoshOrderService.Commands;

public struct ChangeStatusForoshOrderCommand : IRequest<ForoshOrder?>
{
    public Ulid ForoshOrderId { get; set; }
    public Status ForoshOrderStatus { get; set; }
}