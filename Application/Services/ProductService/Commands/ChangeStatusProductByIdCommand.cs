namespace Application.Services.ProductService.Commands;

public struct ChangeStatusProductByIdCommand: IRequest<Product>
{
    public Ulid ProductId { get; set; }
    public Status ProductStatus { get; set; }
}