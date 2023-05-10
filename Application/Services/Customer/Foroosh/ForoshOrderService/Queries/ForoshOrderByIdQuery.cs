namespace Application.Services.Customer.Foroosh.ForoshOrderService.Queries;

public struct GetForooshOrderByIdQuery : IRequest<Result<ForooshOrder>>
{
    public Ulid ForooshOrderId { get; set; }
}