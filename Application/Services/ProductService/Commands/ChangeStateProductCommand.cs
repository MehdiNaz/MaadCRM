namespace Application.Services.ProductService.Commands;

public struct ChangeStateProductCommand : IRequest<Result<ProductResponse>>
{
    public Ulid Id { get; set; }
    public StatusType Status { get; set; }
}