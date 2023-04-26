namespace Application.Services.ProductCustomerFavoritesListService.CommandHandler;

public readonly struct DeleteProductCustomerFavoritesListCommandHandler : IRequestHandler<DeleteProductCustomerFavoritesListCommand, ProductCustomerFavoritesList>
{
    private readonly IProductCustomerFavoritesListRepository _repository;

    public DeleteProductCustomerFavoritesListCommandHandler(IProductCustomerFavoritesListRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCustomerFavoritesList> Handle(DeleteProductCustomerFavoritesListCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteProductCustomerFavoritesListAsync(request.ProductId,request.CustomerId))!;
}