namespace Application.Services.ProductCustomerFavoritesListService.CommandHandler;

public readonly struct CreateProductCustomerFavoritesListCommandHandler : IRequestHandler<CreateProductCustomerFavoritesListCommand, ProductCustomerFavoritesList>
{
    private readonly IProductCustomerFavoritesListRepository _repository;

    public CreateProductCustomerFavoritesListCommandHandler(IProductCustomerFavoritesListRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCustomerFavoritesList> Handle(CreateProductCustomerFavoritesListCommand request, CancellationToken cancellationToken)
    {
        CreateProductCustomerFavoritesListCommand item = new()
        {
            CustomerId = request.CustomerId,
            ProductId = request.ProductId,
        };
        return await _repository.CreateProductCustomerFavoritesListAsync(item);
    }
}