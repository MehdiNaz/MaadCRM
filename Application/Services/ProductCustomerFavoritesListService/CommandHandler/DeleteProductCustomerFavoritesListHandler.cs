namespace Application.Services.ProductCustomerFavoritesListService.CommandHandler;

public class DeleteProductCustomerFavoritesListHandler : IRequestHandler<DeleteProductCustomerFavoritesListCommand, ProductCustomerFavoritesList>
{
    private readonly IProductCustomerFavoritesListRepository _repository;

    public DeleteProductCustomerFavoritesListHandler(IProductCustomerFavoritesListRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCustomerFavoritesList> Handle(DeleteProductCustomerFavoritesListCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteProductCustomerFavoritesListAsync(request.ProductId, request.CustomerId))!;
}