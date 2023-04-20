namespace Application.Services.ForoshOrderService.Commands;

public struct DeleteForoshOrderCommand : IRequest<ForoshOrder>
{
    public Ulid Id { get; set; }
}