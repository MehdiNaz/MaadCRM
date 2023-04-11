namespace Application.Services.ProductService.CommandHandler;

public readonly struct CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product item = new()
        {
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
        await _repository.CreateProductAsync(item);
        return item;
    }
}
