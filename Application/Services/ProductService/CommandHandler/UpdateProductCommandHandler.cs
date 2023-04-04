namespace Application.Services.ProductService.CommandHandler;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
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
        await _repository.UpdateProductAsync(item, request.ProductId);
        return item;
    }
}