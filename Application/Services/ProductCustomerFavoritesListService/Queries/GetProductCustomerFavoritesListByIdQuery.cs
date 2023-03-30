namespace Application.Services.ProductCustomerFavoritesListService.Queries;

public struct GetProductCustomerFavoritesListByIdQuery : IRequest<ProductCustomerFavoritesList>
{
    public Ulid ProductId { get; set; }
    public Ulid CustomerId { get; set; }
}