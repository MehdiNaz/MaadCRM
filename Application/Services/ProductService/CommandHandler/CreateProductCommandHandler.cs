using Application.Responses.Product;

namespace Application.Services.ProductService.CommandHandler;

public readonly struct CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductResponse>>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateProductCommand item = new()
            {
                ProductName = request.ProductName,
                ProductCategoryId = request.ProductCategoryId,
                Title = request.Title,
                Summery = request.Summery,
                Price = request.Price,
                SecondaryPrice = request.SecondaryPrice,
                Discount = request.Discount,
                DiscountPercent = request.DiscountPercent,
                Picture = request.Picture,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };
            return (await _repository.CreateProductAsync(item))
                .Match(result => new Result<ProductResponse>(result),
                    exception => new Result<ProductResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new Exception(e.Message));
        }
    }
}
