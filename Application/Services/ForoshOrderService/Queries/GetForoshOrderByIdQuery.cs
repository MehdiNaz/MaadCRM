namespace Application.Services.ForoshOrderService.Queries;

public struct GetForoshOrderByIdQuery : IRequest<ForoshOrder>
{
    public Ulid ForoshOrderId { get; set; }
}