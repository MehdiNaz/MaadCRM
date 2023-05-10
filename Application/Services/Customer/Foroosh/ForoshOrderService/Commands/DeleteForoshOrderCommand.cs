namespace Application.Services.Customer.Foroosh.ForoshOrderService.Commands;

public struct DeleteForooshOrderCommand : IRequest<Result<ForooshOrder>>
{
    public Ulid Id { get; set; }
}