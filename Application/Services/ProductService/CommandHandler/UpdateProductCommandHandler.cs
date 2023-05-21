using Application.Responses.Product;

namespace Application.Services.ProductService.CommandHandler;

public readonly struct UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductResponse>>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
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

            return (await _repository.UpdateProductAsync(item))
                .Match(result => new Result<ProductResponse>(result),
                    exception => new Result<ProductResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new Exception(e.Message));
        }
    }
}