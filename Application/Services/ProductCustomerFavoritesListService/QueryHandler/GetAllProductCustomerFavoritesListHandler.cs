namespace Application.Services.ProductCustomerFavoritesListService.QueryHandler;

public readonly struct GetAllProductCustomerFavoritesListHandler : IRequestHandler<GetAllProductCustomerFavoritesListQuery, ICollection<ProductCustomerFavoritesList?>>
{
    private readonly IProductCustomerFavoritesListRepository _repository;

    public GetAllProductCustomerFavoritesListHandler(IProductCustomerFavoritesListRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ProductCustomerFavoritesList?>> Handle(GetAllProductCustomerFavoritesListQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllProductCustomerFavoritesListsAsync();
}
