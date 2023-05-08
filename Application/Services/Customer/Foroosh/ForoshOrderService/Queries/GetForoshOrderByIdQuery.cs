namespace Application.Services.Customer.Foroosh.ForooshOrderService.Queries;

public struct GetForooshOrderByIdQuery : IRequest<ForooshOrder>
{
    public Ulid ForooshOrderId { get; set; }
}