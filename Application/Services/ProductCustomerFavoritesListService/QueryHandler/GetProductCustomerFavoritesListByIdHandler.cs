namespace Application.Services.ProductCustomerFavoritesListService.QueryHandler;

public class GetProductCustomerFavoritesListByIdHandler : IRequestHandler<GetProductCustomerFavoritesListByIdQuery, ProductCustomerFavoritesList?>
{
    private readonly IProductCustomerFavoritesListRepository _repository;

    public GetProductCustomerFavoritesListByIdHandler(IProductCustomerFavoritesListRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCustomerFavoritesList?> Handle(GetProductCustomerFavoritesListByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetProductCustomerFavoritesListByIdAsync(request.ProductId, request.CustomerId);
}