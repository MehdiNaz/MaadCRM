namespace Application.Services.ProductCustomerFavoritesListService.Commands;

public struct DeleteProductCustomerFavoritesListCommand : IRequest<ProductCustomerFavoritesList>
{
    public Ulid ProductId { get; set; }
    public Ulid CustomerId { get; set; }
}