namespace Application.Services.Customer.Foroosh.ForooshOrderService.Commands;

public struct ChangeStatusForooshOrderCommand : IRequest<ForooshOrder?>
{
    public Ulid ForooshOrderId { get; set; }
    public Status ForooshOrderStatus { get; set; }
}