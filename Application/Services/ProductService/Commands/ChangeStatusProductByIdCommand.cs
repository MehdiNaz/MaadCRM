namespace Application.Services.ProductService.Commands;

public struct ChangeStatusProductByIdCommand : IRequest<Result<ProductResponse>>
{
    public Ulid ProductId { get; set; }
    public StatusType ProductStatusType { get; set; }
}