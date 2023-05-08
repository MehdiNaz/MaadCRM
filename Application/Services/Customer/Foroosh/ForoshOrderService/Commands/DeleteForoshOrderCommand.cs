namespace Application.Services.Customer.Foroosh.ForooshOrderService.Commands;

public struct DeleteForooshOrderCommand : IRequest<ForooshOrder>
{
    public Ulid Id { get; set; }
}