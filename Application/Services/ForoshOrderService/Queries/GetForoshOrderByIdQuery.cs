namespace Application.Services.ForoshOrderService.Queries;

public class GetForoshOrderByIdQuery : IRequest<ForoshOrder>
{
    public Ulid ForoshOrderId { get; set; }
}