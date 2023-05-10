namespace Application.Services.Customer.Foroosh.ForoshOrderService.Commands;

public struct ChangeStatusForooshOrderCommand : IRequest<Result<ForooshOrder>>
{
    public Ulid ForooshOrderId { get; set; }
    public StatusType ForooshOrderStatusType { get; set; }
}