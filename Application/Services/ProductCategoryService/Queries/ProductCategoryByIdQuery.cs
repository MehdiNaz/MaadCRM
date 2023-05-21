using Application.Responses.Product;

namespace Application.Services.ProductCategoryService.Queries;

public struct ProductCategoryByIdQuery : IRequest<Result<ProductCategoryResponse>>
{
    public Ulid BusinessId { get; set; }
    public Ulid ProductCategoryId { get; set; }
}