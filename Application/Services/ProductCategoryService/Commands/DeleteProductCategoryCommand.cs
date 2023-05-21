using Application.Responses.Product;

namespace Application.Services.ProductCategoryService.Commands;

public struct DeleteProductCategoryCommand : IRequest<Result<ProductCategoryResponse>>
{
    public Ulid Id { get; set; }
}