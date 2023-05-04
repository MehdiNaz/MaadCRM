namespace Application.Services.ProductService.CommandHandler;

public readonly struct UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<Product>>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateProductCommand item = new()
            {
                Id = request.Id,
                ProductName = request.ProductName,
                Title = request.Title,
                Summery = request.Summery,
                Price = request.Price,
                SecondaryPrice = request.SecondaryPrice,
                Discount = request.Discount,
                DiscountPercent = request.DiscountPercent,
                FavoritesListId = request.FavoritesListId,
                Picture = request.Picture,
                IdUserUpdated = request.IdUserUpdated
            };

            return (await _repository.UpdateProductAsync(item)).Match(result => new Result<Product>(result), exception => new Result<Product>(exception));
        }
        catch (Exception e)
        {
            return new Result<Product>(new Exception(e.Message));
        }
    }
}