namespace Application.Services.ProductCustomerFavoritesListService.Commands;

public struct CreateProductCustomerFavoritesListCommand : IRequest<ProductCustomerFavoritesList>
{
    public Ulid ProductId { get; set; }
    public Ulid CustomerId { get; set; }
}