namespace Application.Services.ProductService.CommandHandler;

public readonly struct UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        UpdateProductCommand item = new()
        {
            Id = request.Id,
            ProductName = request.ProductName,
            ProductCategoryId = request.ProductCategoryId,
            Title = request.Title,
            Summery = request.Summery,
            Price = request.Price,
            SecondaryPrice = request.SecondaryPrice,
            Discount = request.Discount,
            DiscountPercent = request.DiscountPercent,
            FavoritesListId = request.FavoritesListId,
            Picture = request.Picture
        };
        return await _repository.UpdateProductAsync(item);
    }
}