namespace Application.Services.ProductCustomerFavoritesListService.CommandHandler;

public class CreateProductCustomerFavoritesListCommandHandler : IRequestHandler<CreateProductCustomerFavoritesListCommand, ProductCustomerFavoritesList>
{
    private readonly IProductCustomerFavoritesListRepository _repository;

    public CreateProductCustomerFavoritesListCommandHandler(IProductCustomerFavoritesListRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCustomerFavoritesList> Handle(CreateProductCustomerFavoritesListCommand request, CancellationToken cancellationToken)
    {
        ProductCustomerFavoritesList item = new()
        {
            CustomerId = request.CustomerId,
            ProductId = request.ProductId,
        };
        await _repository.CreateProductCustomerFavoritesListAsync(item);
        return item;
    }
}