namespace Application.Services.ProductService.Commands;

public struct ChangeStatusProductByIdCommand : IRequest<Result<Product>>
{
    public Ulid ProductId { get; set; }
    public StatusType ProductStatusType { get; set; }
}