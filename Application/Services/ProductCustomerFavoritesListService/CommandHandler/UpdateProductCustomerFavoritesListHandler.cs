namespace Application.Services.ProductCustomerFavoritesListService.CommandHandler;

public class UpdateProductCustomerFavoritesListHandler : IRequestHandler<UpdateProductCustomerFavoritesListCommand, ProductCustomerFavoritesList>
{
    private readonly IProductCustomerFavoritesListRepository _repository;

    public UpdateProductCustomerFavoritesListHandler(IProductCustomerFavoritesListRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCustomerFavoritesList> Handle(UpdateProductCustomerFavoritesListCommand request, CancellationToken cancellationToken)
    {
        ProductCustomerFavoritesList item = new()
        {
            CustomerId = request.CustomerId,
            ProductId = request.ProductId,
        };
        await _repository.UpdateProductCustomerFavoritesListAsync(request.ProductId, request.CustomerId);
        return item;
    }
}